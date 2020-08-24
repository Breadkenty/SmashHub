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

namespace Smash_Combos.Core.Cqrs.Combos.PutCombo
{
    public class PutComboRequestHandler : IRequestHandler<PutComboRequest, PutComboResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PutComboRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PutComboResponse> Handle(PutComboRequest request, CancellationToken cancellationToken)
        {
            var comboExists = await _dbContext.Combos.Where(combo => combo.Id == request.ComboId && combo.UserId == request.UserId).AnyAsync();

            if (!comboExists)
                return new PutComboResponse { Success = false };

            _dbContext.Entry(request.Combo).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync(CancellationToken.None);
                var comboToReturn = await _dbContext.Combos.Where(combo => combo.Id == request.Combo.Id).FirstOrDefaultAsync();
                return new PutComboResponse { Success = true, Combo = _mapper.Map<ComboDto>(comboToReturn) };
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Combos.Any(combo => combo.Id == request.ComboId))
                {
                    return new PutComboResponse { Success = false };
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
