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

namespace Smash_Combos.Core.Cqrs.Reports.GetReports
{
    public class GetReportsRequestHandler : IRequestHandler<GetReportsRequest, GetReportsResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportsRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetReportsResponse> Handle(GetReportsRequest request, CancellationToken cancellationToken)
        {
            User moderator = null;
            try
            {
                moderator = await _dbContext.Users.Where(user => user.Id == request.ModeratorId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new GetReportsResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if (moderator == null)
                return new GetReportsResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if (moderator.UserType == UserType.Moderator || moderator.UserType == UserType.Admin)
            {

                var reports = await _dbContext.Reports
                    .Include(report => report.User)
                    .Include(report => report.Reporter)
                    .Include(report => report.Combo)
                    .Include(report => report.Comment)
                    .ToListAsync();

                return new GetReportsResponse { Data = _mapper.Map<IEnumerable<ReportDto>>(reports), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"{reports.Count} found" };
            }
            else
            {
                return new GetReportsResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to get reports" };
            }
        }
    }
}
