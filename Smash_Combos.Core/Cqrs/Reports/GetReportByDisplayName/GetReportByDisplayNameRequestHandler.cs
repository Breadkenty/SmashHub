using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Reports.GetReportByDisplayName
{
    public class GetReportByDisplayNameRequestHandler : IRequestHandler<GetReportByDisplayNameRequest, IEnumerable<GetReportByDisplayNameResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportByDisplayNameRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetReportByDisplayNameResponse>> Handle(GetReportByDisplayNameRequest request, CancellationToken cancellationToken)
        {
            var reports = await _dbContext.Reports
                .Where(report => report.User.DisplayName == request.DisplayName)
                .Include(report => report.User)
                .Include(report => report.Reporter)
                .ToListAsync();

            if (reports == null)
                return null;

            return _mapper.Map<IEnumerable<GetReportByDisplayNameResponse>>(reports);
        }
    }
}
