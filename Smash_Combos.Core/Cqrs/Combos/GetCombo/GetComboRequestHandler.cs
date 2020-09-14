using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Combos.GetCombo
{
    public class GetComboRequestHandler : IRequestHandler<GetComboRequest, GetComboResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetComboRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetComboResponse> Handle(GetComboRequest request, CancellationToken cancellationToken)
        {
            var combo = await _dbContext.Combos.Where(combo => combo.Id == request.ComboId)
                .Include(combo => combo.User)
                .Include(combo => combo.Character)
                .Include(combo => combo.Comments)
                    .ThenInclude(comment => comment.User)
                .FirstOrDefaultAsync();

            if (combo == null)
                throw new KeyNotFoundException($"Combo with id {request.ComboId} does not exist");

            return _mapper.Map<GetComboResponse>(combo);
        }
    }
}
