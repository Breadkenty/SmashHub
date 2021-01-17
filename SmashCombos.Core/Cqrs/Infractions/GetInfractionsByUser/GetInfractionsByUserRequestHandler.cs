using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Services;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class GetInfractionsByUserRequestHandler : IRequestHandler<GetInfractionsByUserRequest, IEnumerable<GetInfractionsByUserResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInfractionsByUserRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetInfractionsByUserResponse>> Handle(GetInfractionsByUserRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.CurrentUserId);
            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.DisplayName == request.DisplayName);
            if (user == null)
                throw new KeyNotFoundException($"User with name {request.DisplayName} does not exist");

            if (currentUser.Id == user.Id || currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                var infractions = await _dbContext.Infractions
                    .Where(infraction => infraction.User.DisplayName == request.DisplayName)
                    .Include(infraction => infraction.User)
                    .Include(infraction => infraction.Moderator)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<GetInfractionsByUserResponse>>(infractions);
            }
            else
            {
                throw new SecurityException("Not authorized to get infractions");
            }
        }
    }
}
