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

namespace Smash_Combos.Core.Cqrs.Reports.PostCommentReport
{
    public class PostCommentReportRequestHandler : IRequestHandler<PostCommentReportRequest, PostCommentReportResponse>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public PostCommentReportRequestHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PostCommentReportResponse> Handle(PostCommentReportRequest request, CancellationToken cancellationToken)
        {
            User user = null;
            User reporter = null;
            try
            {
                user = await _dbContext.Users.Where(user => user.Id == request.UserId).SingleOrDefaultAsync();
                reporter = await _dbContext.Users.Where(user => user.Id == request.ReporterId).SingleOrDefaultAsync();
            }
            catch (InvalidOperationException)
            {
                return new PostCommentReportResponse { ResponseStatus = ResponseStatus.Error, ResponseMessage = "Multiple Users with same name found" };
            }

            if (user == null || reporter == null)
                return new PostCommentReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "User does not exist" };

            var comment = await _dbContext.Comments.Where(comment => comment.Id == request.CommentId).FirstOrDefaultAsync();

            if (comment == null)
                return new PostCommentReportResponse { ResponseStatus = ResponseStatus.BadRequest, ResponseMessage = "Comment does not exist" };

            var report = new Report
            {
                User = user,
                Reporter = reporter,
                Body = request.Body
            };
            _dbContext.Reports.Add(report);

            comment.Reports.Add(report);
            _dbContext.Entry(comment).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return new PostCommentReportResponse { Data = _mapper.Map<ReportDto>(report), ResponseStatus = ResponseStatus.Ok, ResponseMessage = $"User '{user.DisplayName}' reported" };
        }
    }
}
