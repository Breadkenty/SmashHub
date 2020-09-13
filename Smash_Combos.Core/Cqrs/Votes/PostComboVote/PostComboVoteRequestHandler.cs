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

namespace Smash_Combos.Core.Cqrs.Votes.PostComboVote
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
                throw new KeyNotFoundException("Combo does not exist");

            var existingComboVote = await _dbContext.ComboVotes
                .Include(vote => vote.Combo)
                .Include(vote => vote.User)
                .Where(comboVote => comboVote.Combo.Id == request.ComboId && comboVote.User.Id == request.CurrentUserId)
                .FirstOrDefaultAsync();

            if (existingComboVote != null)
            {
                if (existingComboVote.upOrDown == request.UpOrDown)
                {
                    _dbContext.ComboVotes.Remove(existingComboVote);
                    await _dbContext.SaveChangesAsync(CancellationToken.None);

                    switch (existingComboVote.upOrDown)
                    {
                        case "downvote":
                            combo.VoteUp();
                            break;
                        case "upvote":
                            combo.VoteDown();
                            break;
                        default:
                            throw new ArgumentException("Vote cannot be parsed");
                    }

                    return new PostComboVoteResponse();
                }

                switch (existingComboVote.upOrDown)
                {
                    case "downvote":
                        combo.VoteUp();
                        combo.VoteUp();
                        break;
                    case "upvote":
                        combo.VoteDown();
                        combo.VoteDown();
                        break;
                    default:
                        throw new ArgumentException("Vote cannot be parsed");
                }

                existingComboVote.upOrDown = request.UpOrDown;
                _dbContext.Entry(existingComboVote).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync(CancellationToken.None);
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
                    upOrDown = request.UpOrDown
                };
                await _dbContext.ComboVotes.AddAsync(comboVote);
            }

            switch (request.UpOrDown)
            {
                case "upvote":
                    combo.VoteUp();
                    break;
                case "downvote":
                    combo.VoteDown();
                    break;
                default:
                    throw new ArgumentException("Vote cannot be parsed");
            }

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return new PostComboVoteResponse();
        }
    }
}
