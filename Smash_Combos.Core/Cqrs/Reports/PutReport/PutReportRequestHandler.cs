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

namespace Smash_Combos.Core.Cqrs.Reports.PutReport
{
    public class PutReportRequestHandler : IRequestHandler<PutReportRequest, PutReportResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PutReportRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PutReportResponse> Handle(PutReportRequest request, CancellationToken cancellationToken)
        {
            var report = await _dbContext.Reports.Where(report => report.Id == request.Id).FirstOrDefaultAsync();

            if (report == null)
                return new PutReportResponse { Success = false };

            report.Dismiss = request.Dismiss;

            _dbContext.Entry(report).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync(CancellationToken.None);
                var reportToReturn = await _dbContext.Reports
                                            .Include(report => report.User)
                                            .Include(report => report.Reporter)
                                            .Where(dbReport => dbReport.Id == report.Id)
                                            .FirstOrDefaultAsync();
                return new PutReportResponse { Success = true, Report = _mapper.Map<ReportDto>(reportToReturn) };
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Reports.Any(report => report.Id == request.Id))
                {
                    return new PutReportResponse { Success = false };
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
