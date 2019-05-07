using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Student
    {
        #region Fields
        private string firstName;
        private string lastName;
        private string email;
        private string initial;
        private string faculty;
        private string specialization;
        private bool isRomanian;
        private string studyProgram;
        private string year;
        private string password;
        private string confirmPassword;

        private bool isFemale; //false if it is Male
        private bool isSocialCase;
        private string languageOfStudy;
        private bool isMedicalCase;
        private float media;
        #endregion

        #region Getter&Setters
        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [MinLength(3, ErrorMessage = ResourcesStrings.INVALID)]
        public string FirstName { get => firstName; set => firstName = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [MinLength(3, ErrorMessage = ResourcesStrings.INVALID)]
        public string LastName { get => lastName; set => lastName = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [EmailAddress(ErrorMessage = ResourcesStrings.INVALID)]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [StringLength(1, ErrorMessage = ResourcesStrings.INVALID)]
        public string Initial { get => initial; set => initial = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        public string Faculty { get => faculty; set => faculty = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        public string Specialization { get => specialization; set => specialization = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        public string LanguageOfStudy { get => languageOfStudy; set => languageOfStudy = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        public string StudyProgram { get => studyProgram; set => studyProgram = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [MinLength(1)]
        [MaxLength(1)]
        public string Year { get => year; set => year = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = ResourcesStrings.PASSWORD_SIZE)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = ResourcesStrings.PASSWORD_FORMAT)]
        public string Password { get => password; set => password = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ResourcesStrings.CONFIRM_PASSWORD_UNMATCH)]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }

        [Required]
        public bool IsFemale { get => isFemale; set => isFemale = value; }

        [Required]
        public bool IsSocialCase { get => isSocialCase; set => isSocialCase = value; }

        [Required]
        public bool IsRomanian { get => isRomanian; set => isRomanian = value; }

        [Required]
        public bool IsMedicalCase { get => isMedicalCase; set => isMedicalCase = value; }

        [Required]
        public float Media { get => media; set => media = value; }
        #endregion
    }
}
