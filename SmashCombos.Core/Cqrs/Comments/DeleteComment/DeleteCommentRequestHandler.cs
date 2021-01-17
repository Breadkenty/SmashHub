using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Services;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Core.Cqrs.Comments.DeleteComment
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
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var comment = await _dbContext.Comments
                .Include(comment => comment.User)
                .Where(comment => comment.Id == request.CommentId).FirstOrDefaultAsync();

            if (comment == null)
                throw new KeyNotFoundException($"Comment with id {request.CommentId} does not exist");

            if (comment.User.Id == currentUser.Id || currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                _dbContext.Comments.Remove(comment);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteCommentResponse();
            }
            else
            {
                throw new SecurityException($"Not authorized to delete this comment");
            }
        }
    }
}
