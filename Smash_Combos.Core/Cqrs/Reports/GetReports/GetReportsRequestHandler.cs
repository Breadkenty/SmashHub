using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Reports.GetReports
{
    public class GetReportsRequestHandler : IRequestHandler<GetReportsRequest, IEnumerable<GetReportsResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportsRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetReportsResponse>> Handle(GetReportsRequest request, CancellationToken cancellationToken)
        {
            var reports = await _dbContext.Reports
                .Include(report => report.User)
                .Include(report => report.Reporter)
                .Include(report => report.Combo)
                .Include(report => report.Comment)
                .ToListAsync();

            return _mapper.Map<IEnumerable<GetReportsResponse>>(reports);
        }
    }
}
