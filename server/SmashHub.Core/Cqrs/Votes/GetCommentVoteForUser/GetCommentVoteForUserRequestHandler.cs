using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashHub.Core.Cqrs.Votes.GetCommentVoteForUser
{
    public class GetCommentVoteForUserRequestHandler : IRequestHandler<GetCommentVoteForUserRequest, GetCommentVoteForUserResponse>
    {
        private readonly IDbContext _dbContext;

        public GetCommentVoteForUserRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<GetCommentVoteForUserResponse> Handle(GetCommentVoteForUserRequest request, CancellationToken cancellationToken)
        {
            var commentVote = await _dbContext.CommentVotes
                .Include(commentVote => commentVote.User)
                .Include(commentVote => commentVote.Comment)
                .FirstOrDefaultAsync(commentVote => commentVote.User.Id == request.UserId && commentVote.Comment.Id == request.CommentId);

            if (commentVote == null)
                throw new KeyNotFoundException($"No Vote for User with id {request.UserId} exists for comment with id {request.CommentId}");

            return new GetCommentVoteForUserResponse { IsUpvote = commentVote.IsUpvote };
        }
    }
}
