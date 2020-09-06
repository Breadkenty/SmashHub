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

namespace Smash_Combos.Core.Cqrs.Combos.DeleteCombo
{
    public class DeleteComboRequestHandler : IRequestHandler<DeleteComboRequest, DeleteComboResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;

        public DeleteComboRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<DeleteComboResponse> Handle(DeleteComboRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            try
            {
                user = await _dbContext.Users.Where(user => user.Id == request.UserId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new DeleteComboResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple users with the same name found" };
            }

            if (user == null)
                return new DeleteComboResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "User not found" };

            var combo = await _dbContext.Combos.Where(combo => combo.Id == request.ComboId).FirstOrDefaultAsync();
            if (combo == null)
                return new DeleteComboResponse { ResponseStatus = ResponseStatus.NotFound, ResponseMessage = "Combo not found" };

            if (combo.User.Id == user.Id || user.UserType == UserType.Moderator || user.UserType == UserType.Admin)
            {
                _dbContext.Combos.Remove(combo);
                await _dbContext.SaveChangesAsync(CancellationToken.None);

                return new DeleteComboResponse { Data = _mapper.Map<ComboDto>(combo), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"Combo '{combo.Title}' was deleted" };
            }
            else
            {
                return new DeleteComboResponse { ResponseStatus = ResponseStatus.NotAuthorized, ResponseMessage = "Not authorized to delete this combo" };
            }
        }
    }
}
