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

namespace Smash_Combos.Core.Cqrs.Users.PostUser
{
    public class PostUserRequestHandler : IRequestHandler<PostUserRequest, PostUserResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostUserRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostUserResponse> Handle(PostUserRequest request, CancellationToken cancellationToken)
        {
            var emailExists = _dbContext.Users.Any(existingUser => existingUser.Email.ToLower() == request.Email.ToLower());
            var displayNameExists = _dbContext.Users.Any(existingUser => existingUser.DisplayName.ToLower() == request.DisplayName.ToLower());

            if (displayNameExists)
                return new PostUserResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "There's already an account with this name" };

            if (emailExists)
                return new PostUserResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "There's already an account with this email" };

            var user = _mapper.Map<User>(request);

            if (!user.PasswordMeetsCriteria)
                return new PostUserResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Password must be at least 8 characters" };

            // Indicate to the database context we want to add this new record
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return new PostUserResponse { Data = _mapper.Map<UserDto>(user), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"User '{user.DisplayName}' created" };
        }
    }
}
