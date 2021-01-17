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

namespace SmashCombos.Core.Cqrs.Infractions.DismissInfraction
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
            var currentUser = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == request.CurrentUserId);

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var infraction = await _dbContext.Infractions.Where(infraction => infraction.Id == request.InfractionId).FirstOrDefaultAsync();

            if (infraction == null)
                throw new KeyNotFoundException($"Infraction with id {request.InfractionId} does not exist");

            if (currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                infraction.DismissDate = DateTime.Now;

                _dbContext.Entry(infraction).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new DismissInfractionResponse();
            }
            else
            {
                throw new SecurityException("Not authorized to dismiss infractions");
            }
        }
    }
}
