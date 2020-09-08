using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
            var currentUser = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == request.CurrentUserId);

            if(currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            if (currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                var infraction = await _dbContext.Infractions
                    .Where(infraction => infraction.Id == request.InfractionId)
                    .FirstOrDefaultAsync();

                if (infraction == null)
                    throw new KeyNotFoundException($"Incraftion with id {request.InfractionId} does not exist");

                _dbContext.Infractions.Remove(infraction);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteInfractionResponse { Success = true };
            }
            else
            {
                throw new SecurityException("Not authorized to delete infractions");
            }
        }
    }
}
