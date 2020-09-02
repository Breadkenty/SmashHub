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

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfraction
{
    public class GetInfractionRequestHandler : IRequestHandler<GetInfractionRequest, GetInfractionResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInfractionRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetInfractionResponse> Handle(GetInfractionRequest request, CancellationToken cancellationToken)
        {
            var infraction = await _dbContext.Infractions
                .Where(infraction => infraction.Id == request.InfractionId)
                .Include(infraction => infraction.User)
                .Include(infraction => infraction.Moderator)
                .FirstOrDefaultAsync();

            if (infraction == null)
                return null;

            return _mapper.Map<GetInfractionResponse>(infraction);
        }
    }
}
