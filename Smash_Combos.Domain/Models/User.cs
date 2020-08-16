using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Smash_Combos.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string DisplayName { get; set; }

        [Required]
        public string Email { get; set; }

        [JsonIgnore]
        public string HashedPassword { get; set; }

        [JsonIgnore]
        public bool PasswordMeetsCriteria { get; set; }

        public UserType UserType { get; private set; }

        public List<Combo> Combos { get; set; }

        public List<Comment> Comments { get; set; }

        public List<Infraction> Infractions { get; set; }

        public string Password
        {
            set
            {
                this.PasswordMeetsCriteria = value.Length >= 8;
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