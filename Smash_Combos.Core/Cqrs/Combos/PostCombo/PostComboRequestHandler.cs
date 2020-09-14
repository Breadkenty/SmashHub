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

namespace Smash_Combos.Core.Cqrs.Combos.PostCombo
{
    public class PostComboRequestHandler : IRequestHandler<PostComboRequest, PostComboResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostComboRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostComboResponse> Handle(PostComboRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            var character = await _dbContext.Characters.Where(character => character.Id == request.CharacterId).FirstOrDefaultAsync();

            if (character == null)
                throw new KeyNotFoundException($"Character with id {request.CharacterId} does not exist");

            var combo = new Combo
            {
                Character = character,
                User = currentUser,
                Title = request.Title,
                VideoId = request.VideoId,
                VideoStartTime = request.VideoStartTime,
                VideoEndTime = request.VideoEndTime,
                ComboInput = request.ComboInput,
                TrueCombo = request.TrueCombo,
                Difficulty = request.Difficulty,
                Damage = request.Damage,
                Notes = request.Notes
            };

            _dbContext.Combos.Add(combo);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<PostComboResponse>(combo);
        }
    }
}
