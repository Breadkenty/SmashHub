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

namespace Smash_Combos.Core.Cqrs.Comments.PostComment
{
    public class PostCommentRequestHandler : IRequestHandler<PostCommentRequest, PostCommentResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostCommentRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostCommentResponse> Handle(PostCommentRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var combo = await _dbContext.Combos.Where(combo => combo.Id == request.ComboId).FirstOrDefaultAsync();

            if (combo == null)
                throw new KeyNotFoundException($"Combo with id {request.ComboId} does not exist");

            var comment = new Comment
            {
                User = currentUser,
                Combo = combo,
                Body = request.Body
            };

            _dbContext.Comments.Add(comment);

            combo.Comments.Add(comment);
            _dbContext.Entry(combo).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<PostCommentResponse>(comment);
        }
    }
}
