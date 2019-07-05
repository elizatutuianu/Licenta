using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        private Faculty faculty;
        public int SpecializationId { get; set; }
        [ForeignKey("SpecializationId")]
        private Specialization specialization;
        private string studyProgram; //licenta_z, master_z,licenta_if,  master_if
        private int? year;
        private string taxa_buget;
        private int? group; //grupa studentului

        private bool? isSocialCase;
        private bool? isMedicalCase;
        private double? media;
        private int? credits;
        private string phoneNo;
        public int IdCardStudentId { get; set; }
        [ForeignKey("IdCardStudentId")]
        private IdCardStudent idCardStudent;

        public int? AccomodationRequestId { get; set; }
        [ForeignKey("AccomodationRequestIds")]
        private AccomodationRequest accomodationRequest;

        #endregion

        #region Getter&Setters

        //REGISTER
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [RegularExpression("^[0-9]*$")]
        [MinLength(13, ErrorMessage = ResourcesStrings.INVALID)]
        [MaxLength(13, ErrorMessage = ResourcesStrings.INVALID)]
        public string Cnp { get => cnp; set => cnp = value; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string FirstName { get => firstName; set => firstName = value; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LastName { get => lastName; set => lastName = value; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Initial { get => initial; set => initial = value; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Faculty Faculty { get => faculty; set => faculty = value; }

        public Specialization Specialization { get => specialization; set => specialization = value; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string StudyProgram { get => studyProgram; set => studyProgram = value; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public int? Year { get => year; set => year = value; }

        public bool? IsSocialCase { get => isSocialCase; set => isSocialCase = value; }

        public bool? IsMedicalCase { get => isMedicalCase; set => isMedicalCase = value; }

        public double? Media { get => media; set => media = value; }

        public string Sex { get => sex; set => sex = value; }

        public string Taxa_buget { get => taxa_buget; set => taxa_buget = value; }

        public int? Group { get => group; set => group = value; }

        public int? Credits { get => credits; set => credits = value; }

        public string PhoneNo { get => phoneNo; set => phoneNo = value; }

        public IdCardStudent IdCardStudent { get => idCardStudent; set => idCardStudent = value; }

        public AccomodationRequest AccomodationRequest { get => accomodationRequest; set => accomodationRequest = value; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }



        #endregion
    }
}
