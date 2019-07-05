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

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [EmailAddress(ErrorMessage = ResourcesStrings.INVALID)]
        public string Email { get => email ?? string.Empty; set => email = value ?? string.Empty; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = ResourcesStrings.PASSWORD_SIZE)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = ResourcesStrings.PASSWORD_FORMAT)]
        public string Password { get => password ?? string.Empty; set => password = value ?? string.Empty; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ResourcesStrings.CONFIRM_PASSWORD_UNMATCH)]
        public string ConfirmPassword { get => confirmPassword ?? string.Empty; set => confirmPassword = value ?? string.Empty; }
        public int Id { get => id; set => id = value; }
    }
}
