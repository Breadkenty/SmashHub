using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Services;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Core.Cqrs.Reports.GetReport
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
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            if (currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                var report = await _dbContext.Reports
                    .Where(report => report.Id == request.ReportId)
                    .Include(report => report.User)
                    .Include(report => report.Reporter)
                    .Include(report => report.Combo)
                    .Include(report => report.Comment)
                    .FirstOrDefaultAsync();

                if (report == null)
                    throw new KeyNotFoundException($"Report with id {request.ReportId} does not exist");

                return _mapper.Map<GetReportResponse>(report);
            }
            else
            {
                throw new SecurityException($"Not authorized to get reports");
            }
        }
    }
}
