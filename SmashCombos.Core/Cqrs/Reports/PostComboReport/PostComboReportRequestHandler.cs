using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Services;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Core.Cqrs.Reports.PostComboReport
{
    public class PostComboReportRequestHandler : IRequestHandler<PostComboReportRequest, PostComboReportResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostComboReportRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostComboReportResponse> Handle(PostComboReportRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.Where(user => user.Id == request.UserId).FirstOrDefaultAsync();
            if (user == null)
                throw new KeyNotFoundException($"User with id {request.UserId} does not exist");

            var currentUser = await _dbContext.Users.Where(user => user.Id == request.ReporterId).FirstOrDefaultAsync();
            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.ReporterId} does not exist");

            var reportCombo = await _dbContext.Combos.Where(combo => combo.Id == request.ComboId)
                .Include(combo => combo.Reports)
                    .ThenInclude(report => report.Reporter)
                .FirstOrDefaultAsync();

            if (reportCombo == null)
                throw new KeyNotFoundException($"Combo with id {request.ComboId} does not exist");

            if (reportCombo.Reports.Any(report => report.Reporter.Id == request.ReporterId))
                throw new ArgumentException($"Already reported this combo");

            var report = new Report
            {
                User = user,
                Reporter = currentUser,
                Body = request.Body
            };
            _dbContext.Reports.Add(report);

            reportCombo.Reports.Add(report);
            _dbContext.Entry(reportCombo).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync(CancellationToken.None);


            return _mapper.Map<PostComboReportResponse>(report);

        }
    }
}
