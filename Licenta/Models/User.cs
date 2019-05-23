using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class User
    {
        private string email;
        private string password;
        private string confirmPassword;
        private bool isAdmin;

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [EmailAddress(ErrorMessage = ResourcesStrings.INVALID)]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = ResourcesStrings.PASSWORD_SIZE)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = ResourcesStrings.PASSWORD_FORMAT)]
        public string Password { get => password; set => password = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ResourcesStrings.CONFIRM_PASSWORD_UNMATCH)]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public User(string email, string password, string confirmPassword, bool isAdmin)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            IsAdmin = isAdmin;
        }
    }
}
