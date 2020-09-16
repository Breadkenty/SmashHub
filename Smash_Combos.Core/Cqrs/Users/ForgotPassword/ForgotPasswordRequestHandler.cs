using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Cqrs.Sessions.Login;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Users.ForgotPassword
{
    public class ForgotPasswordRequestHandler : IRequestHandler<ForgotPasswordRequest, ForgotPasswordResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMailSenderService _mailSender;

        public ForgotPasswordRequestHandler(IDbContext dbContext, IMailSenderService mailSender)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mailSender = mailSender ?? throw new ArgumentNullException(nameof(mailSender));
        }

        public async Task<ForgotPasswordResponse> Handle(ForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Email.ToLower() == request.Email.ToLower());

            if (user == null)
                throw new KeyNotFoundException("User with this email doesn't exist");

            var secret = user.HashedPassword + user.DateCreated;

            var payload = new
            {
                user.Id,
                user.Email
            };

            var token = new TokenGenerator(secret).TokenFor(payload);

            var link = $"{request.NewPasswordUrl}/{payload.Id}/{WebUtility.UrlEncode(token)}";

            await _mailSender.SendPasswordResetMailAsync(user.Email, link);

            return new ForgotPasswordResponse();
        }
    }
}
