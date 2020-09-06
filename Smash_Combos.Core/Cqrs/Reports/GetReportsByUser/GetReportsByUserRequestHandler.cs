using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportsByUser
{
    public class GetReportsByUserRequestHandler : IRequestHandler<GetReportsByUserRequest, GetReportsByUserResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportsByUserRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetReportsByUserResponse> Handle(GetReportsByUserRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            User moderator = null;
            try
            {
                user = await _dbContext.Users.Where(user => user.DisplayName == request.UserName).SingleOrDefaultAsync();
                moderator = await _dbContext.Users.Where(user => user.Id == request.ModeratorId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new GetReportsByUserResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Name found" };
            }

            if (user == null || moderator == null)
                return new GetReportsByUserResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if (moderator.UserType == UserType.Moderator || moderator.UserType == UserType.Admin)
            {
                var reports = await _dbContext.Reports
                    .Where(report => report.User.DisplayName == request.UserName)
                    .Include(report => report.User)
                    .Include(report => report.Reporter)
                    .Include(report => report.Comment)
                        .ThenInclude(comment => comment.Combo)
                            .ThenInclude(combo => combo.Character)
                    .Include(report => report.Combo)
                        .ThenInclude(combo => combo.Character)
                    .ToListAsync();

                return new GetReportsByUserResponse { Data = _mapper.Map<IEnumerable<ReportDto>>(reports), ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = $"{reports.Count} found" };
            }
            else
            {
                return new GetReportsByUserResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Not authorized to get reports" };
            }
        }
    }
}
