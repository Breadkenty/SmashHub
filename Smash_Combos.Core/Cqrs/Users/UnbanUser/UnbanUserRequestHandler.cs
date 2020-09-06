using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Cqrs.Characters.GetCharacter;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            User moderator = null;
            User user = null;
            try
            {
                moderator = await _dbContext.Users.Where(user => user.Id == request.ModeratorId).SingleOrDefaultAsync();
                user = await _dbContext.Users.Include(user => user.Combos)
                    .Include(user => user.Comments)
                    .Include(user => user.Combos)
                    .Include(user => user.Infractions)
                    .SingleOrDefaultAsync(user => user.Id == request.UserId);
            }
            catch (InvalidOperationException)
            {
                return new UnbanUserResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if (user == null || moderator == null)
                return new UnbanUserResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User doesn't exist" };

            if(moderator.UserType == UserType.Moderator || moderator.UserType == UserType.Admin)
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

                return new UnbanUserResponse { Data = _mapper.Map<UserFullDto>(user), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"User '{user.DisplayName}' unbanned" };
            }
            else
            {
                return new UnbanUserResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to unban Users" };
            }
        }
    }
}
