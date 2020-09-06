using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
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
            User moderator = null;
            try
            {
                moderator = await _dbContext.Users.Where(user => user.Id == request.ModeratorId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new GetReportResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if (moderator == null)
                return new GetReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if (moderator.UserType == UserType.Moderator || moderator.UserType == UserType.Admin)
            {

                var report = await _dbContext.Reports
                .Where(report => report.Id == request.ReportId)
                .Include(report => report.User)
                .Include(report => report.Reporter)
                .Include(report => report.Combo)
                .Include(report => report.Comment)
                .FirstOrDefaultAsync();

                if (report == null)
                    return new GetReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Report does not exist" };

                return new GetReportResponse {Data = _mapper.Map<ReportDto>(report), ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Report does not exist" };
            }
            else
            {
                return new GetReportResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Not authorized to get reports" };
            }
        }
    }
}
