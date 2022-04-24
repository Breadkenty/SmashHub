using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashHub.Core.Services;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashHub.Core.Cqrs.Votes.PostComboVote
{
    public class PostComboVoteRequestHandler : IRequestHandler<PostComboVoteRequest, PostComboVoteResponse>
    {
        private readonly IDbContext _dbContext;

        public PostComboVoteRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<PostComboVoteResponse> Handle(PostComboVoteRequest request, CancellationToken cancellationToken)
        {
            var combo = await _dbContext.Combos.FindAsync(request.ComboId);

            if (combo == null)
                throw new KeyNotFoundException($"Combo with id {request.ComboId} does not exist");

            var existingComboVote = await _dbContext.ComboVotes
                .Include(vote => vote.Combo)
                .Include(vote => vote.User)
                .Where(comboVote => comboVote.Combo.Id == request.ComboId && comboVote.User.Id == request.CurrentUserId)
                .FirstOrDefaultAsync();

            if (existingComboVote != null)
            {
                if (existingComboVote.IsUpvote == request.IsUpVote)
                {
                    _dbContext.ComboVotes.Remove(existingComboVote);

                    if (existingComboVote.IsUpvote)
                        combo.VoteDown();
                    else
                        combo.VoteUp();

                    await _dbContext.SaveChangesAsync(CancellationToken.None);
                    return new PostComboVoteResponse();
                }

                if (existingComboVote.IsUpvote)
                {
                    combo.VoteDown();
                    combo.VoteDown();
                }
                else
                {
                    combo.VoteUp();
                    combo.VoteUp();
                }

                existingComboVote.IsUpvote = request.IsUpVote;
                _dbContext.Entry(existingComboVote).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new PostComboVoteResponse();
            }
            else
            {
                var user = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).FirstOrDefaultAsync();

                if (user == null)
                    throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

                var comboVote = new ComboVote
                {
                    Combo = combo,
                    User = user,
                    IsUpvote = request.IsUpVote
                };

                if (comboVote.IsUpvote)
                    combo.VoteUp();
                else
                    combo.VoteDown();

                await _dbContext.ComboVotes.AddAsync(comboVote);
                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new PostComboVoteResponse();
            }
        }
    }
}
