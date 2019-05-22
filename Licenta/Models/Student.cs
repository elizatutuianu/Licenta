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
        private string email;
        private string password;
        private string confirmPassword;
        private string cnp;

        private string firstName;
        private string lastName;
        private string initial;
        private DateTime birthDate;
        private string sex;
        private string country;
        private Faculty faculty;
        private Specialization specialization;
        private string studyProgram; //licenta_z, master_z,licenta_if,  master_if
        private string year;
        private string taxa_buget;
        private int group;//grupa studentului

        private bool isSocialCase;
        private string languageOfStudy;
        private bool isMedicalCase;
        private float media;
        private int credits;
        private string phoneNo;
        private string idCardNo;
        private string idCardIssuedBy;
        private DateTime idCardIssuedDate;
        private string district;
        private string localty;
        private string address;
        private string civilStatus;
        //private string brothersInASE; //optional

        private AccomodationRequest accomodationRequest;

        #endregion

        #region Getter&Setters

        //REGISTER
        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [EmailAddress(ErrorMessage = ResourcesStrings.INVALID)]
        public string Email { get => email; set => email = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [RegularExpression("^[0-9]*$")]
        [MinLength(13, ErrorMessage = ResourcesStrings.INVALID)]
        [MaxLength(13, ErrorMessage = ResourcesStrings.INVALID)]
        public string Cnp { get => cnp; set => cnp = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = ResourcesStrings.PASSWORD_SIZE)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = ResourcesStrings.PASSWORD_FORMAT)]
        public string Password { get => password; set => password = value; }

        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = ResourcesStrings.CONFIRM_PASSWORD_UNMATCH)]
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }

        //HOME PAGE STUDENT
        public string FirstName { get => firstName; set => firstName = value; }

        public string LastName { get => lastName; set => lastName = value; }

        public string Initial { get => initial; set => initial = value; }

        public Faculty Faculty { get => faculty; set => faculty = value; }

        public Specialization Specialization { get => specialization; set => specialization = value; }

        public string LanguageOfStudy { get => Specialization.SpecLanguageOfStudy; }

        public string StudyProgram { get => studyProgram; set => studyProgram = value; }

        public string Year { get => year; set => year = value; }

        public bool IsSocialCase { get => isSocialCase; set => isSocialCase = value; }

        public bool IsMedicalCase { get => isMedicalCase; set => isMedicalCase = value; }

        public float Media { get => media; set => media = value; }

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }

        public string Sex { get => sex; set => sex = value; }

        public string Country { get => country; set => country = value; }

        public string Taxa_buget { get => taxa_buget; set => taxa_buget = value; }

        public int Group { get => group; set => group = value; }

        public int Credits { get => credits; set => credits = value; }

        public string PhoneNo { get => phoneNo; set => phoneNo = value; }

        public string IdCardNo { get => idCardNo; set => idCardNo = value; }

        public string IdCardIssuedBy { get => idCardIssuedBy; set => idCardIssuedBy = value; }

        public DateTime IdCardIssuedDate { get => idCardIssuedDate; set => idCardIssuedDate = value; }

        public string District { get => district; set => district = value; }

        public string Localty { get => localty; set => localty = value; }

        public string Address { get => address; set => address = value; }

        public string CivilStatus { get => civilStatus; set => civilStatus = value; }
        public AccomodationRequest AccomodationRequest { get => accomodationRequest; set => accomodationRequest = value; }

        //e nevoie de fielduri by default null??
        public Student(string email, string cnp, string password, string confirmPassword,
            string firstName, string lastName, string initial, Faculty faculty,
            Specialization specialization, string studyProgram, string year,
            bool isSocialCase, bool isMedicalCase, float media, DateTime birthDate,
            string sex, string country, string taxa_buget, int group, int credits,
            string phoneNo, string idCardNo, string idCardIssuedBy, DateTime idCardIssuedDate,
            string district, string localty, string address, string civilStatus)
        {
            Email = email;
            Cnp = cnp;
            Password = password;
            ConfirmPassword = confirmPassword;
            FirstName = firstName;
            LastName = lastName;
            Initial = initial;
            Faculty = faculty;
            Specialization = specialization;
            StudyProgram = studyProgram;
            Year = year;
            IsSocialCase = isSocialCase;
            IsMedicalCase = isMedicalCase;
            Media = media;
            BirthDate = birthDate;
            Sex = sex;
            Country = country;
            Taxa_buget = taxa_buget;
            Group = group;
            Credits = credits;
            PhoneNo = phoneNo;
            IdCardNo = idCardNo;
            IdCardIssuedBy = idCardIssuedBy;
            IdCardIssuedDate = idCardIssuedDate;
            District = district;
            Localty = localty;
            Address = address;
            CivilStatus = civilStatus;
        }
        #endregion


    }
}
