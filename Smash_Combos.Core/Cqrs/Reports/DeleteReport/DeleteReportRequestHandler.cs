using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Reports.DeleteReport
{
    public class DeleteReportRequestHandler : IRequestHandler<DeleteReportRequest, DeleteReportResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteReportRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteReportResponse> Handle(DeleteReportRequest request, CancellationToken cancellationToken)
        {
            var report = await _dbContext.Reports
                                .Include(report => report.User)
                                .Include(report => report.Reporter)
                                .Where(report => report.Id == request.ReportId && report.User.Id == request.UserId)
                                .FirstOrDefaultAsync();
            if (report == null)
            {
                return new DeleteReportResponse { Success = false };
            }

            _dbContext.Reports.Remove(report);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return new DeleteReportResponse { Success = true, Report = _mapper.Map<ReportDto>(report) };
        }
    }
}
