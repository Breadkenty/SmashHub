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

namespace Smash_Combos.Core.Cqrs.Characters.PutCharacter
{
    public class PutCharacterRequestHandler : IRequestHandler<PutCharacterRequest, PutCharacterResponse>
    {
        private readonly IDbContext _dbContext;

        public PutCharacterRequestHandler(IDbContext context)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PutCharacterResponse> Handle(PutCharacterRequest request, CancellationToken cancellationToken)
        {
            User currentUser = null;
            try
            {
                currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new PutCharacterResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same Id found" };
            }

            if (currentUser == null)
                return new PutCharacterResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            if (currentUser.UserType == UserType.Admin)
            {
                var character = await _dbContext.Characters.Where(character => character.VariableName == request.VariableName).FirstOrDefaultAsync();

                if(character == null)
                    return new PutCharacterResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Character does not exist" };

                character.Name = request.Name;
                character.VariableName = request.VariableName;
                character.ReleaseOrder = request.ReleaseOrder;
                character.YPosition = request.YPosition;

                _dbContext.Entry(character).State = EntityState.Modified;

                try
                {
                    await _dbContext.SaveChangesAsync(CancellationToken.None);
                    return new PutCharacterResponse { ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Character updated" };
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new PutCharacterResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Something went wrong, please try again" };
                }
            }
            else
            {
                return new PutCharacterResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to edit characters" };
            }
        }
    }
}
