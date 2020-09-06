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

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfraction
{
    public class GetInfractionRequestHandler : IRequestHandler<GetInfractionRequest, GetInfractionResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInfractionRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetInfractionResponse> Handle(GetInfractionRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            try
            {
                user = await _dbContext.Users.Where(user => user.Id == request.ModeratorId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new GetInfractionResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if (user == null)
                return new GetInfractionResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if(user.UserType == UserType.Moderator || user.UserType == UserType.Admin)
            {
                var infraction = await _dbContext.Infractions
                    .Where(infraction => infraction.Id == request.InfractionId)
                    .Include(infraction => infraction.User)
                    .Include(infraction => infraction.Moderator)
                    .FirstOrDefaultAsync();

                if (infraction == null)
                    return new GetInfractionResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Infraction not found" };

                return new GetInfractionResponse { Data = _mapper.Map<InfractionDto>(infraction), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Infraction found" };
            }
            else
            {
                return new GetInfractionResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Not authorized to get infractions" };
            }
        }
    }
}
