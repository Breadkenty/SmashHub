using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Combos.GetCombo
{
    public class GetComboRequestHandler : IRequestHandler<GetComboRequest, GetComboResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetComboRequestHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetComboResponse> Handle(GetComboRequest request, CancellationToken cancellationToken)
        {
            var combo = await _dbContext.Combos.Where(combo => combo.Id == request.ComboID).Include(combo => combo.User).Include(combo => combo.Comments).FirstOrDefaultAsync();

            if (combo == null)
                return null;

            return _mapper.Map<GetComboResponse>(combo);
        }
    }
}
