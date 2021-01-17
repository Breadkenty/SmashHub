using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Core.Cqrs.Comments.GetComments
{
    public class GetCommentsRequestHandler : IRequestHandler<GetCommentsRequest, IEnumerable<GetCommentsResponse>>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCommentsRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<GetCommentsResponse>> Handle(GetCommentsRequest request, CancellationToken cancellationToken)
        {
            var comments = await _dbContext.Comments
                .Include(comment => comment.User)
                .Include(comment => comment.Reports)
                    .ThenInclude(report => report.User)
                .ToListAsync();

            return _mapper.Map<IEnumerable<GetCommentsResponse>>(comments);
        }
    }
}
