using AutoMapper;
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

namespace Smash_Combos.Core.Cqrs.Combos.PutCombo
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
            var user = await _dbContext.Users.Where(user => user.Id == request.User.Id).SingleOrDefaultAsync();

            if (user == null)
                return new PutComboResponse { Data = null, ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Couldn't find User" };

            var combo = await _dbContext.Combos.Where(combo => combo.Id == request.Id).FirstOrDefaultAsync();

            if (combo == null)
                return new PutComboResponse { Data = null, ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Couldn't find Combo" };

            if (combo.User.Id != user.Id && user.UserType != UserType.Admin)
                return new PutComboResponse { Data = null, ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to edit this Combo" };

            var character = await _dbContext.Characters.Where(character => character.VariableName == request.Character.VariableName).FirstOrDefaultAsync();

            if (character == null)
                return new PutComboResponse { Data = null, ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Couldn't find Character" };

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

            try
            {
                await _dbContext.SaveChangesAsync(CancellationToken.None);
                var comboToReturn = await _dbContext.Combos.Where(combo => combo.Id == request.Id).FirstOrDefaultAsync();
                return new PutComboResponse { Data = _mapper.Map<ComboDto>(comboToReturn), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Combo updated" };
            }
            catch (DbUpdateConcurrencyException)
            {
                return new PutComboResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Something went wrong, please try again" };
            }
        }
    }
}
