using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Cqrs.Sessions.Login;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Users.ResetPassword
{
    public class NewPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
    {

        private readonly IDbContext _dbContext;

        public NewPasswordRequestHandler(IDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == request.UserId);

            if (user == null)
                throw new KeyNotFoundException("User with this id doesn't exist");

            var secret = user.HashedPassword + user.DateCreated;


            try
            {
                var isValidToken = new TokenGenerator(secret).ValidateToken(request.Token);
                if (isValidToken)
                {
                    user.Password = request.ResetPassword;
                    if (!user.PasswordMeetsCriteria)
                        throw new ArgumentException("Password must be at least 8 characters");

                    _dbContext.Entry(user).State = EntityState.Modified;

                    await _dbContext.SaveChangesAsync(CancellationToken.None);

                    return new ResetPasswordResponse();
                }
                else
                {
                    throw new ArgumentException("Security token doesn't match");
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException("Invalid Reset Link");
            }

        }
    }
}
