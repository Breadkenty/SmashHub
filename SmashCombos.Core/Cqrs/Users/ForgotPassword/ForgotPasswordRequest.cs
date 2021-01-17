using MediatR;
using Microsoft.AspNetCore.Identity;
using SmashCombos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmashCombos.Core.Cqrs.Users.ForgotPassword
{
    public class ForgotPasswordRequest : IRequest<ForgotPasswordResponse>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string NewPasswordUrl { get; set; }
    }
}
