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
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == request.Email.ToLower());

            if (user == null)
                throw new KeyNotFoundException("User with this email doesn't exist");

            var secret = user.HashedPassword + DateTime.Now.Millisecond;

            var token = new TokenGenerator(secret).TokenFor(user);

            //this url should send the user to a /newpassword page where they can enter their new password
            //from that page, then call the api/users/newpassword method to save the new password
            var link = $"{request.NewPasswordUrl}?userId={user.Id}&token={WebUtility.UrlEncode(token)}";
            var mailBody = $"Click the following link to reset your password:\n\n{link}";

            await _mailSender.SendMailAsync(user.Email, "Password Reset", mailBody);

            return new ForgotPasswordResponse();
        }
    }
}
