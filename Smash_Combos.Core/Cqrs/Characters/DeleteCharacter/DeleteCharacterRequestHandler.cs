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

namespace Smash_Combos.Core.Cqrs.Characters.DeleteCharacter
{
    public class DeleteCharacterRequestHandler : IRequestHandler<DeleteCharacterRequest, DeleteCharacterResponse>
    {
        private readonly IDbContext _dbContext;

        public DeleteCharacterRequestHandler(IDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<DeleteCharacterResponse> Handle(DeleteCharacterRequest request, CancellationToken cancellationToken)
        {
            User currentUser = null;
            try
            {
                currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new DeleteCharacterResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if (currentUser == null)
                return new DeleteCharacterResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if (currentUser.UserType == UserType.Admin)
            {
                var character = await _dbContext.Characters
                    .Where(character => character.Id == request.CharacterId)
                    .FirstOrDefaultAsync();

                if (character == null)
                    return new DeleteCharacterResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Character does not exist" };

                _dbContext.Characters.Remove(character);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteCharacterResponse { ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Character deleted" };
            }
            else
            {
                return new DeleteCharacterResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to delete characters" };
            }
        }
    }
}
