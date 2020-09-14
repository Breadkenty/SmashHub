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

namespace Smash_Combos.Core.Cqrs.Votes.PostCommentVote
{
    public class PostCommentVoteRequestHandler : IRequestHandler<PostCommentVoteRequest, PostCommentVoteResponse>
    {
        private readonly IDbContext _dbContext;

        public PostCommentVoteRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<PostCommentVoteResponse> Handle(PostCommentVoteRequest request, CancellationToken cancellationToken)
        {
            var comment = await _dbContext.Comments.FindAsync(request.CommentId);

            if (comment == null)
                throw new KeyNotFoundException($"Comment with id {request.CommentId} does not exist");

            var existingCommentVote = await _dbContext.CommentVotes
                .Include(vote => vote.Comment)
                .Include(vote => vote.User)
                .Where(commentVote => commentVote.Comment.Id == request.CommentId && commentVote.User.Id == request.CurrentUserId)
                .FirstOrDefaultAsync();

            if (existingCommentVote != null)
            {
                if (existingCommentVote.IsUpvote == request.IsUpVote)
                {
                    _dbContext.CommentVotes.Remove(existingCommentVote);

                    if (existingCommentVote.IsUpvote)
                        comment.VoteDown();
                    else
                        comment.VoteUp();

                    await _dbContext.SaveChangesAsync(CancellationToken.None);
                    return new PostCommentVoteResponse();
                }

                if (existingCommentVote.IsUpvote)
                {
                    comment.VoteDown();
                    comment.VoteDown();
                }
                else
                {
                    comment.VoteUp();
                    comment.VoteUp();
                }

                existingCommentVote.IsUpvote = request.IsUpVote;
                _dbContext.Entry(existingCommentVote).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new PostCommentVoteResponse();
            }
            else
            {
                var user = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).FirstOrDefaultAsync();

                if (user == null)
                    throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

                var commentVote = new CommentVote
                {
                    Comment = comment,
                    User = user,
                    IsUpvote = request.IsUpVote
                };

                if (request.IsUpVote)
                    comment.VoteUp();
                else
                    comment.VoteDown();

                await _dbContext.CommentVotes.AddAsync(commentVote);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new PostCommentVoteResponse();
            }
        }
    }
}
