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
        private bool isRoLanguage;
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
        [Required(ErrorMessage ="You need to fill this space")]
        [MinLength(3, ErrorMessage="Invalid name")]
        public string FirstName { get => firstName; set => firstName = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        [MinLength(3, ErrorMessage = "Invalid name")]
        public string LastName { get => lastName; set => lastName = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        [EmailAddress(ErrorMessage="Invalid email format")]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        [StringLength(1)]
        public string Initial { get => initial; set => initial = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        public string Faculty { get => faculty; set => faculty = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        public string Specialization { get => specialization; set => specialization = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        public string LanguageOfStudy { get => languageOfStudy; set => languageOfStudy = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        public string StudyProgram { get => studyProgram; set => studyProgram = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        [MinLength(1)]
        [MaxLength(1)]
        public string Year { get => year; set => year = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get => password; set => password = value; }

        [Required(ErrorMessage = "You need to fill this space")]
        [DataType(DataType.Password)]
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
