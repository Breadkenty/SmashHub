using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
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
            User moderator = null;
            try
            {
                moderator = await _dbContext.Users.Where(user => user.Id == request.ModeratorId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new DeleteReportResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if (moderator == null)
                return new DeleteReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if (moderator.UserType == UserType.Moderator || moderator.UserType == UserType.Admin)
            {
                var report = await _dbContext.Reports
                    .Where(report => report.Id == request.ReportId && report.User.Id == request.ModeratorId)
                    .FirstOrDefaultAsync();
                
                if (report == null)
                    return new DeleteReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Report does not exist" };

                _dbContext.Reports.Remove(report);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteReportResponse { Data = _mapper.Map<ReportDto>(report), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Report deleted" };
            }
            else
            {
                return new DeleteReportResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Not authorized to delete reports" };
            }
        }
    }
}
