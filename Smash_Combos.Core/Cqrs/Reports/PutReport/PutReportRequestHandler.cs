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
            User user = null;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.ModeratorId);
            }
            catch (InvalidOperationException)
            {
                return new PutReportResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Name found" };
            }

            if (user == null)
                return new PutReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            var report = await _dbContext.Reports.Where(report => report.Id == request.ReportId).FirstOrDefaultAsync();

            if (report == null)
                return new PutReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Report does not exist" };

            if (user.UserType == UserType.Moderator || user.UserType == UserType.Admin)
            {
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
                    return new PutReportResponse { Data = _mapper.Map<ReportDto>(reportToReturn), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Report does not exist" };
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new PutReportResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Something went wrong, please try again" };

                }
            }
            else
            {
                return new PutReportResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to edit reports" };
            }
        }
    }
}
