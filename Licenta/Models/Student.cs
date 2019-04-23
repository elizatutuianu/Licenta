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
        private char initial;
        private string faculty;
        private string specialization;
        private bool isRoLanguage;
        private string studyProgram;
        private int year;
        private string password;
        private string confirmPassword;

        private bool isFemale; //false if it is Male
        private bool isSocialCase;
        private bool isRomanian;
        private bool isMedicalCase;
        private float media;
        #endregion

        #region Getter&Setters
        [Required]
        [MinLength(3)]
        public string FirstName { get => firstName; set => firstName = value; }
        [Required]
        [MinLength(3)]
        public string LastName { get => lastName; set => lastName = value; }
        [Required]
        [EmailAddress]
        public string Email { get => email; set => email = value; }
        [Required]
        [StringLength(1)]
        public char Initial { get => initial; set => initial = value; }
        [Required]
        public string Faculty { get => faculty; set => faculty = value; }
        [Required]
        public string Specialization { get => specialization; set => specialization = value; }
        [Required]
        public bool IsRoLanguage { get => isRoLanguage; set => isRoLanguage = value; }
        [Required]
        public string StudyProgram { get => studyProgram; set => studyProgram = value; }
        [Required]
        [StringLength(4)]
        public int Year { get => year; set => year = value; }
        [Required]
        public string Password { get => password; set => password = value; }
        [Required]
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
