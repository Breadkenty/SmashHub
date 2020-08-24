using AutoMapper;
using MediatR;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Combos.PostCombo
{
    public class PostComboRequestHandler : IRequestHandler<PostComboRequest, PostComboResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostComboRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostComboResponse> Handle(PostComboRequest request, CancellationToken cancellationToken)
        {
            request.Combo.UserId = request.UserId;

            _dbContext.Combos.Add(request.Combo);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<PostComboResponse>(request.Combo);
        }
    }
}
