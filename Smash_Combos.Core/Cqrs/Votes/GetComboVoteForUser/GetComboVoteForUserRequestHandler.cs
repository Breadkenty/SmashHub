using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Votes.GetComboVoteForUser
{
    public class GetComboVoteForUserRequestHandler
    {
        private readonly IDbContext _dbContext;

        public GetComboVoteForUserRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<GetComboVoteForUserResponse> Handle(GetComboVoteForUserRequest request, CancellationToken cancellationToken)
        {
            var commentVote = await _dbContext.ComboVotes
                .Include(commentVote => commentVote.User)
                .Include(commentVote => commentVote.Combo)
                .FirstOrDefaultAsync(commentVote => commentVote.User.Id == request.UserId && commentVote.Combo.Id == request.ComboId);

            if (commentVote == null)
                throw new KeyNotFoundException($"No Vote for User with id {request.UserId} exists for combo with id {request.ComboId}");

            return new GetComboVoteForUserResponse { IsUpvote = commentVote.IsUpvote };
        }
    }
}
