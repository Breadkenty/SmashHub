using AutoMapper;
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

namespace Smash_Combos.Core.Cqrs.Characters.PostCharacter
{
    public class PostCharacterRequestHandler : IRequestHandler<PostCharacterRequest, PostCharacterResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostCharacterRequestHandler(IDbContext context, IMapper mapper)
        {
            _dbContext = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostCharacterResponse> Handle(PostCharacterRequest request, CancellationToken cancellationToken)
        {
            var currentUser = await _dbContext.Users.Where(user => user.Id == request.CurrentUserId).SingleOrDefaultAsync();

            if (currentUser == null)
                throw new KeyNotFoundException($"User with id {request.CurrentUserId} does not exist");

            if (currentUser.UserType == UserType.Admin)
            {
                var character = new Character
                {
                    Name = request.Name,
                    VariableName = request.VariableName,
                    ReleaseOrder = request.ReleaseOrder,
                    YPosition = request.YPosition
                };

                _dbContext.Characters.Add(character);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return _mapper.Map<PostCharacterResponse>(character);
            }
            else
            {
                throw new SecurityException("Not authorized to create characters");
            }
        }
    }
}
