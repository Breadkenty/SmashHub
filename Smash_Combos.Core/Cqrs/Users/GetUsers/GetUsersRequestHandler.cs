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

namespace Smash_Combos.Core.Cqrs.Users.GetUsers
{
    public class GetUsersRequestHandler : IRequestHandler<GetUsersRequest, GetUsersResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUsersRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetUsersResponse> Handle(GetUsersRequest request, CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users
                        .Include(user => user.Combos)
                            .ThenInclude(combo => combo.Reports)
                        .Include(user => user.Combos)
                            .ThenInclude(combo => combo.Character)
                        .Include(user => user.Comments)
                            .ThenInclude(comment => comment.Reports)
                        .Include(user => user.Infractions)
                            .ThenInclude(infraction => infraction.Moderator)
                        .ToListAsync();

            var responseList = new List<UserFullDto>();

            foreach(var user in users)
            {
                var dto = new UserFullDto
                {
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                    UserType = user.UserType,
                    Combos = _mapper.Map<List<ComboDto>>(user.Combos),
                    Comments = _mapper.Map<List<CommentDto>>(user.Comments),
                    Infractions = _mapper.Map<List<InfractionDto>>(user.Infractions)
                };
                responseList.Add(dto);
            }

            return new GetUsersResponse { Data = responseList, ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"{responseList.Count} found" };
        }
    }
}
