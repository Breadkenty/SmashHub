using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmashHub.Core.Services;
using SmashHub.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmashHub.Core.Cqrs.Users.GetUser
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
            var currentUser = await _dbContext.Users.SingleOrDefaultAsync(user => user.Id == request.CurrentUserId);

            var user = await _dbContext.Users
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

            if (user == null)
                throw new KeyNotFoundException("User does not exist");

            var response = new GetUserResponse
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                UserType = user.UserType,
                Combos = _mapper.Map<List<ComboDto>>(user.Combos),
                Comments = _mapper.Map<List<CommentDto>>(user.Comments),
                Infractions = _mapper.Map<List<InfractionDto>>(user.Infractions)
            };

            if (currentUser == null || (currentUser.UserType != UserType.Moderator && currentUser.UserType != UserType.Admin))
            {
                foreach (var combo in response.Combos)
                {
                    combo.Reports = new List<ReportDto>();
                }

                if (currentUser == null || currentUser.Id != user.Id)
                {
                    response.Infractions = new List<InfractionDto>();
                }
            }

            return response;
        }
    }
}
