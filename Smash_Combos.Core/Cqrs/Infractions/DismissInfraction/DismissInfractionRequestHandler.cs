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

namespace Smash_Combos.Core.Cqrs.Infractions.DismissInfraction
{
    public class DismissInfractionRequestHandler : IRequestHandler<DismissInfractionRequest, DismissInfractionResponse>
    {
        private readonly IDbContext _dbContext;

        public DismissInfractionRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task<DismissInfractionResponse> Handle(DismissInfractionRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.ModeratorId);
            }
            catch (InvalidOperationException)
            {
                return new DismissInfractionResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Name found" };
            }

            if (user == null)
                return new DismissInfractionResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            var infraction = await _dbContext.Infractions.Where(infraction => infraction.Id == request.InfractionId).FirstOrDefaultAsync();

            if (infraction == null)
                return new DismissInfractionResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Infraction does not exist" };

            if (user.UserType == UserType.Moderator || user.UserType == UserType.Admin)
            {
                infraction.DismissDate = DateTime.Now;

                _dbContext.Entry(infraction).State = EntityState.Modified;

                try
                {
                    await _dbContext.SaveChangesAsync(CancellationToken.None);
                    return new DismissInfractionResponse { ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Infraction dismissed" };
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new DismissInfractionResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Something went wrong, please try again" };

                }
            }
            else
            {
                return new DismissInfractionResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to dismiss reports" };
            }
        }
    }
}
