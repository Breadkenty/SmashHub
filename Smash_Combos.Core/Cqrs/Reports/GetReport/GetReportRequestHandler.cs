using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Reports.GetReport
{
    public class GetReportRequestHandler : IRequestHandler<GetReportRequest, GetReportResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetReportResponse> Handle(GetReportRequest request, CancellationToken cancellationToken)
        {
            var report = await _dbContext.Reports
                .Where(report => report.Id == request.ReportId)
                .Include(report => report.User)
                .Include(report => report.Reporter)
                .Include(report => report.Combo)
                .Include(report => report.Comment)
                .FirstOrDefaultAsync();

            if (report == null)
                return null;

            return _mapper.Map<GetReportResponse>(report);
        }
    }
}
