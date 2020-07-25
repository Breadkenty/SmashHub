using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Smash_Combos.Models
{
    public class User
    {
        public int Id { get; set; }

        public bool Admin { get; private set; } = false;

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Combo> Combos { get; private set; }
        public List<Comment> Comments { get; private set; }

        [JsonIgnore]
        public string HashedPassword { get; set; }

        public string Password
        {
            set
            {
                this.HashedPassword = new PasswordHasher<User>().HashPassword(this, value);
            }
        }

        public bool IsValidPassword(string password)
        {
            var passwordVerification = new PasswordHasher<User>().VerifyHashedPassword(this, this.HashedPassword, password);

            return passwordVerification == PasswordVerificationResult.Success;
        }


    }
}