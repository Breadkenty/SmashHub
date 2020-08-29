using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
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
            var infraction = await _dbContext.Infractions.Where(infraction => infraction.Id == request.InfractionId && infraction.User.Id == request.UserId).FirstOrDefaultAsync();
            if (infraction == null)
            {
                return new DeleteInfractionResponse { Success = false };
            }

            _dbContext.Infractions.Remove(infraction);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return new DeleteInfractionResponse { Success = true, Infraction = _mapper.Map<InfractionDto>(infraction) };
        }
    }
}
