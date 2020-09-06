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

namespace Smash_Combos.Core.Cqrs.Infractions.DeleteInfraction
{
    public class DeleteInfractionRequestHandler : IRequestHandler<DeleteInfractionRequest, DeleteInfractionResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteInfractionRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteInfractionResponse> Handle(DeleteInfractionRequest request, CancellationToken cancellationToken)
        {
            User moderator = null;
            try
            {
                moderator = await _dbContext.Users.Where(user => user.Id == request.ModeratorId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new DeleteInfractionResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if(moderator == null)
                return new DeleteInfractionResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if(moderator.UserType == UserType.Moderator || moderator.UserType == UserType.Admin)
            {
                var infraction = await _dbContext.Infractions
                                .Where(infraction => infraction.Id == request.InfractionId)
                                .FirstOrDefaultAsync();

                if (infraction == null)
                    return new DeleteInfractionResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Infraction does not exist" };

                _dbContext.Infractions.Remove(infraction);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteInfractionResponse { Data = _mapper.Map<InfractionDto>(infraction), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Infraction deleted" };
            }
            else
            {
                return new DeleteInfractionResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Not authorized to delete infractions" };
            }
        }
    }
}
