using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashCombos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashCombos.Core.Cqrs.Characters.GetCharacter
{
    public class GetCharacterRequestHandler : IRequestHandler<GetCharacterRequest, GetCharacterResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCharacterRequestHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCharacterResponse> Handle(GetCharacterRequest request, CancellationToken cancellationToken)
        {
            var character = await _dbContext.Characters.Where(character => character.VariableName == request.VariableName)
                    .Include(character => character.Combos)
                        .ThenInclude(combo => combo.User)
                    .FirstOrDefaultAsync();

            if (character == null)
                throw new KeyNotFoundException($"Character with name {request.VariableName} does not exist");

            return _mapper.Map<GetCharacterResponse>(character);
        }
    }
}
