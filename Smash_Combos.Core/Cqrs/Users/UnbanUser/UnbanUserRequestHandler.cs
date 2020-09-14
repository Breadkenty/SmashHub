using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Cqrs.Characters.GetCharacter;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Users.UnbanUser
{
    public class UnbanUserRequestHandler : IRequestHandler<UnbanUserRequest, UnbanUserResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public UnbanUserRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UnbanUserResponse> Handle(UnbanUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();
            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var user = await _dbContext.Users.Include(user => user.Combos)
                .Include(user => user.Comments)
                .Include(user => user.Combos)
                .Include(user => user.Infractions)
                .SingleOrDefaultAsync(user => user.Id == request.UserId);

            if (user == null)
                throw new KeyNotFoundException($"User with id {request.UserId} does not exist");

            if (currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                var infractions = await _dbContext.Infractions.Where(infraction => infraction.User.Id == request.UserId).ToListAsync();

                foreach (var infraction in infractions)
                {
                    if (infraction.IsActiveBan())
                    {
                        infraction.DismissDate = DateTime.Now;
                    }
                }

                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return _mapper.Map<UnbanUserResponse>(user);
            }
            else
            {
                throw new SecurityException("Not authorized to unban Users");
            }
        }
    }
}
