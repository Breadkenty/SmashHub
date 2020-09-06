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

namespace Smash_Combos.Core.Cqrs.Infractions.PostInfraction
{
    public class PostInfractionRequestHandler : IRequestHandler<PostInfractionRequest, PostInfractionResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostInfractionRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostInfractionResponse> Handle(PostInfractionRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.Where(user => user.DisplayName == request.User.DisplayName).FirstOrDefaultAsync();
            var moderator = await _dbContext.Users.Where(user => user.DisplayName == request.Moderator.DisplayName).FirstOrDefaultAsync();

            if (user == null || moderator == null)
                return new PostInfractionResponse { User = null, Moderator = null };

            var infraction = new Infraction
            {
                User = user,
                Moderator = moderator,
                Body = request.Body,
                BanDuration = request.BanDuration,
                Category = request.Category,
                Points = DeterminePoints(request)
            };
            _dbContext.Infractions.Add(infraction);

            user.Infractions.Add(infraction);
            _dbContext.Entry(user).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return _mapper.Map<PostInfractionResponse>(infraction);
        }

        private int? DeterminePoints(PostInfractionRequest request)
        {
            if (request.Points != null)
                return request.Points;

            return request.Category switch
            {
                InfractionCategory.Spam => 1,
                InfractionCategory.Inappropriate => 1,
                InfractionCategory.Harassment => 2,
                InfractionCategory.Other => request.Points,
                _ => null,
            };
        }
    }
}
