using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportsByUser
{
    public class GetReportsByUserRequestHandler : IRequestHandler<GetReportsByUserRequest, IEnumerable<GetReportsByUserResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportsByUserRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetReportsByUserResponse>> Handle(GetReportsByUserRequest request, CancellationToken cancellationToken)
        {
            var reports = await _dbContext.Reports
                .Where(report => report.User.DisplayName == request.UserName)
                .Include(report => report.User)
                .Include(report => report.Reporter)
                .Include(report => report.Comment)
                    .ThenInclude(comment => comment.Combo)
                        .ThenInclude(combo => combo.Character)
                .Include(report => report.Combo)
                    .ThenInclude(combo => combo.Character)
                .ToListAsync();

            if (reports == null)
                return null;

            return _mapper.Map<IEnumerable<GetReportsByUserResponse>>(reports);
        }
    }
}
