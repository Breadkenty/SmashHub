using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class GetInfractionsByUserRequestHandler : IRequestHandler<GetInfractionsByUserRequest, GetInfractionsByUserResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInfractionsByUserRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetInfractionsByUserResponse> Handle(GetInfractionsByUserRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            User currentUser = null;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(user => user.DisplayName == request.DisplayName);
                currentUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.UserId);
            }
            catch (InvalidOperationException)
            {
                return new GetInfractionsByUserResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Name found" };
            }

            if(user == null || currentUser == null)
                return new GetInfractionsByUserResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if (currentUser.Id == user.Id || currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                var infractions = await _dbContext.Infractions
                    .Where(infraction => infraction.User.DisplayName == request.DisplayName)
                    .Include(infraction => infraction.User)
                    .Include(infraction => infraction.Moderator)
                    .ToListAsync();

                return new GetInfractionsByUserResponse { Data = _mapper.Map<IEnumerable<InfractionDto>>(infractions), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"{infractions.Count} found" };
            }
            else
            {
                return new GetInfractionsByUserResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to get infractions" };
            }
        }
    }
}
