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
            var infraction = await _dbContext.Infractions.Where(infraction => infraction.Id == request.Id).FirstOrDefaultAsync();

            if (infraction == null)
                return new PutInfractionResponse { Success = false };

            infraction.BanDuration = request.BanDuration;
            infraction.Points = request.Points;
            infraction.Category = request.Category;
            infraction.Body = request.Body;

            if (request.LiftBan)
                infraction.BanLiftDate = DateTime.Now;

            _dbContext.Entry(infraction).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync(CancellationToken.None);
                var infractionToReturn = await _dbContext.Infractions
                                                .Include(infraction => infraction.User)
                                                .Include(infraction => infraction.Moderator)
                                                .Where(infraction => infraction.Id == request.Id)
                                                .FirstOrDefaultAsync();
                return new PutInfractionResponse { Success = true, Infraction = _mapper.Map<InfractionDto>(infractionToReturn) };
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Infractions.Any(infraction => infraction.Id == request.Id))
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
