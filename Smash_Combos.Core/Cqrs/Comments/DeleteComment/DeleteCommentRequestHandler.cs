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

namespace Smash_Combos.Core.Cqrs.Comments.DeleteComment
{
    public class DeleteCommentRequestHandler : IRequestHandler<DeleteCommentRequest, DeleteCommentResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteCommentRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteCommentResponse> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            try
            {
                user = await _dbContext.Users.Where(user => user.Id == request.UserId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new DeleteCommentResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple users with the same name found" };
            }

            if(user == null)
                return new DeleteCommentResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "User not found" };

            var comment = await _dbContext.Comments.Where(comment => comment.Id == request.CommentId).FirstOrDefaultAsync();
            if (comment == null)
                return new DeleteCommentResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Comment not found" };

            if (comment.User.Id != user.Id && user.UserType == UserType.User)
                return new DeleteCommentResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to delete this comment" };

            _dbContext.Comments.Remove(comment);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return new DeleteCommentResponse { Data = _mapper.Map<CommentDto>(comment), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Comment was deleted" };
        }
    }
}
