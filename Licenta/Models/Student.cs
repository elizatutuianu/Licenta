using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Student : User
    {
        #region Fields
        private string cnp;

        private string firstName;
        private string lastName;
        private string initial;
        private string sex;
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

        private IdCardStudent IdCardStudent;
        //private string brothersInASE; //optional

        private AccomodationRequest accomodationRequest;

        #endregion

        #region Getter&Setters

        //REGISTER
        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [RegularExpression("^[0-9]*$")]
        [MinLength(13, ErrorMessage = ResourcesStrings.INVALID)]
        [MaxLength(13, ErrorMessage = ResourcesStrings.INVALID)]
        public string Cnp { get => cnp; set => cnp = value; }

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

        public string Sex { get => sex; set => sex = value; }

        public string Taxa_buget { get => taxa_buget; set => taxa_buget = value; }

        public int Group { get => group; set => group = value; }

        public int Credits { get => credits; set => credits = value; }

        public string PhoneNo { get => phoneNo; set => phoneNo = value; }

        public AccomodationRequest AccomodationRequest { get => accomodationRequest; set => accomodationRequest = value; }
        public IdCardStudent IdCardStudent1 { get => IdCardStudent; set => IdCardStudent = value; }
        public string LanguageOfStudy1 { get => languageOfStudy; set => languageOfStudy = value; }

        //e nevoie de fielduri by default null??
        //public Student(string cnp, string firstName, string lastName, string initial,
        //    Faculty faculty, Specialization specialization, string studyProgram, string year,
        //    bool isSocialCase, bool isMedicalCase, float media, DateTime birthDate,
        //    string sex, string country, string taxa_buget, int group, int credits,
        //    string phoneNo, string idCardNo, string idCardIssuedBy, DateTime idCardIssuedDate,
        //    string district, string localty, string address, string civilStatus, string email,
        //    string password, string confirmPassword, bool isAdmin = false)
        //    : base(email, password, confirmPassword, isAdmin)
        //{
        //    Cnp = cnp;
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Initial = initial;
        //    Faculty = faculty;
        //    Specialization = specialization;
        //    StudyProgram = studyProgram;
        //    Year = year;
        //    IsSocialCase = isSocialCase;
        //    IsMedicalCase = isMedicalCase;
        //    Media = media;
        //    BirthDate = birthDate;
        //    Sex = sex;
        //    Country = country;
        //    Taxa_buget = taxa_buget;
        //    Group = group;
        //    Credits = credits;
        //    PhoneNo = phoneNo;
        //    IdCardNo = idCardNo;
        //    IdCardIssuedBy = idCardIssuedBy;
        //    IdCardIssuedDate = idCardIssuedDate;
        //    District = district;
        //    Localty = localty;
        //    Address = address;
        //    CivilStatus = civilStatus;
        //}
        #endregion


    }
}
