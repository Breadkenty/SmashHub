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

namespace Smash_Combos.Core.Cqrs.Infractions.GetInfractionsByUser
{
    public class GetInfractionsByUserRequestHandler : IRequestHandler<GetInfractionsByUserRequest, IEnumerable<GetInfractionsByUserResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetInfractionsByUserRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetInfractionsByUserResponse>> Handle(GetInfractionsByUserRequest request, CancellationToken cancellationToken)
        {
            var infractions = await _dbContext.Infractions
                .Where(infraction => infraction.User.DisplayName == request.UserName)
                .Include(infraction => infraction.User)
                .Include(infraction => infraction.Moderator)
                .ToListAsync();

            return _mapper.Map<IEnumerable<GetInfractionsByUserResponse>>(infractions);
        }
    }
}
