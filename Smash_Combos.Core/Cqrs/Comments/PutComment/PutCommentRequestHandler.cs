using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            User user = null;
            try
            {
                user = await _dbContext.Users.Where(user => user.Id == request.UserId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new PutCommentResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple users with the same name found" };
            }

            if (user == null)
                return new PutCommentResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "User not found" };

            var comment = await _dbContext.Comments.Where(comment => comment.Id == request.CommentId).FirstOrDefaultAsync();

            if (comment == null)
                return new PutCommentResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Comment not found" };

            if (comment.User.Id != user.Id && user.UserType == UserType.User)
                return new PutCommentResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to edit this comment" };

            comment.Body = request.Body;

            _dbContext.Entry(comment).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync(CancellationToken.None);
                var commentToReturn = await _dbContext.Comments
                    .Include(comment => comment.User)
                    .Where(comment => comment.Id == request.CommentId)
                    .FirstOrDefaultAsync();
                return new PutCommentResponse { Data = _mapper.Map<CommentDto>(commentToReturn), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Comment edited" };
            }
            catch (DbUpdateConcurrencyException)
            {
                return new PutCommentResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Something went wrong, please try again" };
            }
        }
    }
}
