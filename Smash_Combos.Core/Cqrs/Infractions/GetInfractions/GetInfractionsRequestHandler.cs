using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractions
{
    public class GetInfractionsRequestHandler : IRequestHandler<GetInfractionsRequest, IEnumerable<GetInfractionsResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInfractionsRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetInfractionsResponse>> Handle(GetInfractionsRequest request, CancellationToken cancellationToken)
        {
            var infractions = await _dbContext.Infractions
                .Include(infraction => infraction.User)
                .Include(infraction => infraction.Moderator)
                .ToListAsync();

            return _mapper.Map<IEnumerable<GetInfractionsResponse>>(infractions);
        }
    }
}
