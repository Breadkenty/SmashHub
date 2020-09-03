﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Smash_Combos.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smash_Combos.Core.Cqrs.Combos.GetCombos
{
    public class GetCombosRequestHandler : IRequestHandler<GetCombosRequest, GetCombosResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCombosRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetCombosResponse> Handle(GetCombosRequest request, CancellationToken cancellationToken)
        {
            var combos = await _dbContext.Combos
                .Include(combo => combo.User)
                .Include(combo => combo.Comments)
                    .ThenInclude(comment => comment.User)
                .ToListAsync();

            return new GetCombosResponse { Data = _mapper.Map<IEnumerable<ComboDto>>(combos), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"{combos.Count} found" };
        }
    }
}
