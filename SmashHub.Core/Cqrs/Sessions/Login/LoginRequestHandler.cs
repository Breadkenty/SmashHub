using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmashHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashHub.Core.Cqrs.Sessions.Login
{
    public class LoginRequestHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly string JWT_KEY;

        public LoginRequestHandler(IDbContext dbContext, IMapper mapper, IConfiguration config)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            if (config == null)
                throw new ArgumentNullException(nameof(config));

            JWT_KEY = config["JWT_KEY"];
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var foundUser = await _dbContext.Users.Include(x => x.Infractions).SingleOrDefaultAsync(user => user.Email.ToLower() == request.Email.ToLower());

            if (foundUser == null)
                throw new ArgumentException("Invalid password or email");

            if (foundUser.IsValidPassword(request.Password))
            {
                foreach (var infraction in foundUser.Infractions)
                {
                    if (infraction.IsActiveBan())
                        throw new ArgumentException("User is currently banned");
                }
                var user = _mapper.Map<UserDto>(foundUser);
                return new LoginResponse { Token = new TokenGenerator(JWT_KEY).TokenFor(user), User = user };
            }
            else
            {
                throw new ArgumentException("Invalid password or email");
            }
        }
    }
}
