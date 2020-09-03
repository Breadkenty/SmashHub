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
            var character = await _dbContext.Characters.Where(character => character.Id == request.CharacterId).FirstOrDefaultAsync();
            var user = await _dbContext.Users.Where(user => user.Id == request.UserId).SingleOrDefaultAsync();

            if (user == null)
                return new PostComboResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "User not found" };
            if(character == null)
                return new PostComboResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Character not found" };

            var combo = new Combo
            {
                Character = character,
                User = user,
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

            return new PostComboResponse { Data = _mapper.Map<ComboDto>(combo), ResponseStatus = ResponseStatus.Ok, ResponseMessage = "Combo created" };
        }
    }
}
