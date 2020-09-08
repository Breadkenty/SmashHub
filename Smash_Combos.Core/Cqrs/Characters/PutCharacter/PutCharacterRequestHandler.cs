using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            if (currentUser.UserType == UserType.Admin)
            {
                var character = await _dbContext.Characters.Where(character => character.VariableName == request.VariableName).FirstOrDefaultAsync();

                if (character == null)
                    throw new KeyNotFoundException($"Character with name {request.VariableName} does not exist");

                character.Name = request.Name;
                character.VariableName = request.VariableName;
                character.ReleaseOrder = request.ReleaseOrder;
                character.YPosition = request.YPosition;

                _dbContext.Entry(character).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new PutCharacterResponse { Success = true };
            }
            else
            {
                throw new SecurityException("Not authorized to edit characters");
            }
        }
    }
}
