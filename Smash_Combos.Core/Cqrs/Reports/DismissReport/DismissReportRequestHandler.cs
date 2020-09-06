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

namespace Smash_Combos.Core.Cqrs.Reports.DismissReport
{
    public class DismissReportRequestHandler : IRequestHandler<DismissReportRequest, DismissReportResponse>
    {
        private readonly IDbContext _dbContext;

        public DismissReportRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<DismissReportResponse> Handle(DismissReportRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            try
            {
                user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.ModeratorId);
            }
            catch (InvalidOperationException)
            {
                return new DismissReportResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Name found" };
            }

            if (user == null)
                return new DismissReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            var report = await _dbContext.Reports.Where(report => report.Id == request.ReportId).FirstOrDefaultAsync();

            if (report == null)
                return new DismissReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Report does not exist" };

            if (user.UserType == UserType.Moderator || user.UserType == UserType.Admin)
            {
                report.Dismiss = request.Dismiss;

                _dbContext.Entry(report).State = EntityState.Modified;

                try
                {
                    await _dbContext.SaveChangesAsync(CancellationToken.None);
                    return new DismissReportResponse { ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Report dismissed" };
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new DismissReportResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Something went wrong, please try again" };

                }
            }
            else
            {
                return new DismissReportResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to dismiss reports" };
            }
        }
    }
}
