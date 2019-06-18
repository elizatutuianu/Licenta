using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class User
    {
        [Key]
        private int id;
        private string email;
        private string password;
        private string confirmPassword;

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
        public int Id { get => id; set => id = value; }
    }
}
