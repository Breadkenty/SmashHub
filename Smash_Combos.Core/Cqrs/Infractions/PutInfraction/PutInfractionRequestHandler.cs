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

namespace Smash_Combos.Core.Cqrs.Infractions.PutInfraction
{
    public class PutInfractionRequestHandler : IRequestHandler<PutInfractionRequest, PutInfractionResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PutInfractionRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PutInfractionResponse> Handle(PutInfractionRequest request, CancellationToken cancellationToken)
        {
            var infractionExists = await _dbContext.Infractions.Where(infraction => infraction.Id == request.InfractionId && infraction.User.Id == request.UserId).AnyAsync();

            if (!infractionExists)
                return new PutInfractionResponse { Success = false };

            _dbContext.Entry(request.Infraction).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync(CancellationToken.None);
                var comboToReturn = await _dbContext.Infractions.Where(infraction => infraction.Id == request.Infraction.Id).FirstOrDefaultAsync();
                return new PutInfractionResponse { Success = true, Infraction = _mapper.Map<InfractionDto>(comboToReturn) };
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Combos.Any(combo => combo.Id == request.InfractionId))
                {
                    return new PutInfractionResponse { Success = false };
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
