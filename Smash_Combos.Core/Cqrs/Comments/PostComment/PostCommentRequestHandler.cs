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
            User user = null;
            try
            {
                user = await _dbContext.Users.Where(user => user.Id == request.UserId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new PostCommentResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple users with the same name found" };
            }

            if (user == null)
                return new PostCommentResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "User not found" };

            var combo = await _dbContext.Combos.Where(combo => combo.Id == request.ComboId).FirstOrDefaultAsync();

            if (combo == null)
                return new PostCommentResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Combo not found" };

            var comment = new Comment
            {
                User = user,
                Combo = combo,
                Body = request.Body
            };

            _dbContext.Comments.Add(comment);

            combo.Comments.Add(comment);
            _dbContext.Entry(combo).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return new PostCommentResponse { Data = _mapper.Map<CommentDto>(comment), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Comment created" };
        }
    }
}
