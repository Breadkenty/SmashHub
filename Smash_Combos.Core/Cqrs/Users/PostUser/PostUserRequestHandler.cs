using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Users.PostUser
{
    public class PostUserRequestHandler : IRequestHandler<PostUserRequest, PostUserResponse>
    {
        private readonly IDbContext _dbContext;

        public PostUserRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<PostUserResponse> Handle(PostUserRequest request, CancellationToken cancellationToken)
        {
            var emailExists = _dbContext.Users.Any(existingUser => existingUser.Email.ToLower() == request.User.Email.ToLower());
            var displayNameExists = _dbContext.Users.Any(existingUser => existingUser.DisplayName.ToLower() == request.User.DisplayName.ToLower());

            if (displayNameExists)
                return new PostUserResponse { DisplayNameAlreadyExists = true };

            if (emailExists)
                return new PostUserResponse { EmailAlreadyExists = true };

            if (!request.User.PasswordMeetsCriteria)
                return new PostUserResponse { PasswordDoesntMeetCriteria = true };


            // Indicate to the database context we want to add this new record
            _dbContext.Users.Add(request.User);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return new PostUserResponse { User = request.User };
        }
    }
}
