using MediatR;
using Microsoft.AspNetCore.Identity;
using Smash_Combos.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Smash_Combos.Core.Cqrs.Users.ForgotPassword
{
    public class ForgotPasswordRequest : IRequest<ForgotPasswordResponse>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
