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

namespace Smash_Combos.Core.Cqrs.Reports.PostComboReport
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
            var user = await _dbContext.Users.Where(user => user.DisplayName == request.User.DisplayName).FirstOrDefaultAsync();
            var reporter = await _dbContext.Users.Where(user => user.DisplayName == request.Reporter.DisplayName).FirstOrDefaultAsync();
            var reportCombo = await _dbContext.Combos.Where(combo => combo.Id == request.ComboId).FirstOrDefaultAsync();

            if (user == null || reporter == null || reportCombo == null)
                return new PostComboReportResponse { User = null, Reporter = null };

            var report = new Report
            {
                User = user,
                Reporter = reporter,
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
