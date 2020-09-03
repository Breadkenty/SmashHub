using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportsByDisplayName
{
    public class GetReportsByDisplayNameRequestHandler : IRequestHandler<GetReportsByDisplayNameRequest, IEnumerable<GetReportsByDisplayNameResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportsByDisplayNameRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetReportsByDisplayNameResponse>> Handle(GetReportsByDisplayNameRequest request, CancellationToken cancellationToken)
        {
            var reports = await _dbContext.Reports
                .Where(report => report.User.DisplayName == request.DisplayName)
                .Include(report => report.User)
                .Include(report => report.Reporter)
                .Include(report => report.Comment)
                .Include(report => report.Combo)
                .ToListAsync();

            if (reports == null)
                return null;

            return _mapper.Map<IEnumerable<GetReportsByDisplayNameResponse>>(reports);
        }
    }
}
