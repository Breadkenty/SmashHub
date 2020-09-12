using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Comments.PutComment
{
    public class PutCommentRequestHandler : IRequestHandler<PutCommentRequest, PutCommentResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PutCommentRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PutCommentResponse> Handle(PutCommentRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var comment = await _dbContext.Comments.Include(comment => comment.User).Where(comment => comment.Id == request.CommentId).FirstOrDefaultAsync();

            if (comment == null)
                throw new KeyNotFoundException($"Comment with id {request.CommentId} does not exist");

            if (comment.User.Id == currentUser.Id || currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                comment.Body = request.Body;

                _dbContext.Entry(comment).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new PutCommentResponse();
            }
            else
            {
                throw new SecurityException("Not authorized to edit this comment");
            }
        }
    }
}
