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

namespace Smash_Combos.Core.Cqrs.Users.GetUser
{
    public class PostUserRequestHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostUserRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            try
            {
                user = await _dbContext.Users
                    .Include(user => user.Combos)
                        .ThenInclude(combo => combo.Reports)
                    .Include(user => user.Combos)
                        .ThenInclude(combo => combo.Character)
                    .Include(user => user.Comments)
                        .ThenInclude(comment => comment.Reports)
                    .Include(user => user.Infractions)
                        .ThenInclude(infraction => infraction.Moderator)
                    .Where(user => user.DisplayName == request.DisplayName)
                    .SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return null; //This is temporary. If everyone agrees with my proposed ResponseBase object we will be able to return a nice error message here.
            }

            if (user == null)
                return null;

            var response = new GetUserResponse
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                UserType = user.UserType,
                Combos = _mapper.Map<List<ComboDto>>(user.Combos),
                Comments = _mapper.Map<List<CommentDto>>(user.Comments),
                Infractions = _mapper.Map<List<InfractionDto>>(user.Infractions)
            };

            return response;
        }
    }
}
