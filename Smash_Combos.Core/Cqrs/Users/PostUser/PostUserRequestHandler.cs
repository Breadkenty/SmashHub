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
                throw new ArgumentException("User with this name already exists");

            if (emailExists)
                throw new ArgumentException("User with this email already exists");

            var user = _mapper.Map<User>(request);

            if (!user.PasswordMeetsCriteria)
                throw new ArgumentException("Password must be at least 8 characters");

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<PostUserResponse>(user);
        }
    }
}
