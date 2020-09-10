using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Cqrs.Sessions.Login;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Users.ForgotPassword
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public ForgotPasswordRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == request.Email.ToLower());

            if (user == null)
                return new ForgotPasswordResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            var selectedUser = new UserDto
            {
                HashedPassword = user.HashedPassword,
            };

            var payload = new UserDto
            {
                Id = user.Id,
                Email = request.Email,
            };

            var secret = selectedUser.HashedPassword + DateTime.Now.Millisecond;

            var token = new TokenGenerator(secret).TokenFor(user);

            return new ForgotPasswordResponse { Token = token, UserId = payload.Id };
        }
    }
}
