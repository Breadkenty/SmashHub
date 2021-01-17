using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Services;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Core.Cqrs.Characters.DeleteCharacter
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
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            if (currentUser.UserType == UserType.Admin)
            {
                var character = await _dbContext.Characters
                    .Where(character => character.Id == request.CharacterId)
                    .FirstOrDefaultAsync();

                if (character == null)
                    throw new KeyNotFoundException($"User with id {request.CharacterId} does not exist");

                _dbContext.Characters.Remove(character);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteCharacterResponse();
            }
            else
            {
                throw new SecurityException("Not authorized to create characters");
            }
        }
    }
}
