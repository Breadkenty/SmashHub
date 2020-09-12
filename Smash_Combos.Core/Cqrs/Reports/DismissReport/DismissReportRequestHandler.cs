using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
            var currentUser = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.CurrentUserId);

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var report = await _dbContext.Reports.Include(report => report.User).Where(report => report.Id == request.ReportId).FirstOrDefaultAsync();

            if (report == null)
                throw new KeyNotFoundException($"Report with id {request.CurrentUserId} does not exist");

            if (currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                if (report.User.Id == currentUser.Id)
                    throw new ArgumentException("Moderators cannot dismiss their own reports");

                report.Dismiss = request.Dismiss;

                _dbContext.Entry(report).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new DismissReportResponse();
            }
            else
            {
                throw new SecurityException("Not authorized to dismiss reports");
            }
        }
    }
}
