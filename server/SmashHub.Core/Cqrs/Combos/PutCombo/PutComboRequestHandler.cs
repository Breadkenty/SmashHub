using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashHub.Core.Services;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashHub.Core.Cqrs.Combos.PutCombo
{
    public class PutComboRequestHandler : IRequestHandler<PutComboRequest, PutComboResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PutComboRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PutComboResponse> Handle(PutComboRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var combo = await _dbContext.Combos.Include(combo => combo.User).Where(combo => combo.Id == request.ComboId).FirstOrDefaultAsync();

            if (combo == null)
                throw new KeyNotFoundException($"Combo with id {request.ComboId} does not exist");

            if (combo.User.Id == currentUser.Id || currentUser.UserType == UserType.Moderator || currentUser.UserType == UserType.Admin)
            {
                var character = await _dbContext.Characters.Where(character => character.VariableName == request.CharacterVariableName).FirstOrDefaultAsync();

                if (character == null)
                    throw new KeyNotFoundException($"Character with VariableName {request.CharacterVariableName} does not exist");

                combo.Character = character;
                combo.Title = request.Title;
                combo.VideoId = request.VideoId;
                combo.VideoStartTime = request.VideoStartTime;
                combo.VideoEndTime = request.VideoEndTime;
                combo.ComboInput = request.ComboInput;
                combo.TrueCombo = request.TrueCombo; ;
                combo.Difficulty = request.Difficulty;
                combo.Damage = request.Damage;
                combo.Notes = request.Notes;

                _dbContext.Entry(combo).State = EntityState.Modified;

                await _dbContext.SaveChangesAsync(CancellationToken.None);
                return new PutComboResponse();
            }
            else
            {
                throw new SecurityException("Not authorized to edit this Combo");
            }
        }
    }
}
