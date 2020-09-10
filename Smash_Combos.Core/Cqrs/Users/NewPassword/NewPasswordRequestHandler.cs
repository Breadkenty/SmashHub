using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Users.NewPassword
{
    public class NewPasswordRequestHandler : IRequestHandler<NewPasswordRequest, NewPasswordResponse>
    {
        public async Task<NewPasswordResponse> Handle(NewPasswordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //Generate a token again (the same way you did it in the forgotpassword handler) and compare it to the one in the request
            //if it's the same, then we can set the password to the new one the user has set (remember to check if it fits the constraints)
        }
    }
}
