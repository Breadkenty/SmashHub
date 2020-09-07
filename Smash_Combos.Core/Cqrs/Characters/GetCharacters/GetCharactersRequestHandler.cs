using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Characters.GetCharacters
{
    public class GetCharactersRequestHandler : IRequestHandler<GetCharactersRequest, GetCharactersResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCharactersRequestHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCharactersResponse> Handle(GetCharactersRequest request, CancellationToken cancellationToken)
        {
            if (request.Filter == null)
            {
                var characters = await _dbContext.Characters.ToListAsync();
                return new GetCharactersResponse { Data = _mapper.Map<IEnumerable<CharacterDto>>(characters), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"{characters.Count} found" };
            }
            else
            {
                var characters = await _dbContext.Characters
                    .Where(character => character.Name.ToLower().Contains(request.Filter) || character.VariableName.ToLower().Contains(request.Filter))
                    .ToListAsync();
                return new GetCharactersResponse { Data = _mapper.Map<IEnumerable<CharacterDto>>(characters), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"{characters.Count} found" };
            }
        }
    }
}
