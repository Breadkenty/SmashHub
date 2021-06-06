using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashHub.Core.Services;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace SmashHub.Core.Cqrs.Reports.DeleteReport
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
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            if (currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                var report = await _dbContext.Reports
                    .Where(report => report.Id == request.ReportId && report.User.Id == request.CurrentUserId)
                    .FirstOrDefaultAsync();

                if (report == null)
                    throw new KeyNotFoundException($"Report with id {request.ReportId} does not exist");

                _dbContext.Reports.Remove(report);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteReportResponse();
            }
            else
            {
                throw new SecurityException("Not authorized to delete reports");
            }
        }
    }
}
