using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Specialization
    {
        [Key]
        private int id;
        private string specName;
        private int specNoOfStudents;
        private int specNoOfFemaleStudents;
        private string specLanguageOfStudy;

        public int? FacultyId { get; set; }
        [ForeignKey("FacultyId")]
        public Faculty Faculty { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SpecName { get => specName ?? string.Empty; set => specName = value ?? string.Empty; }
        public int SpecNoOfStudents { get => specNoOfStudents; set => specNoOfStudents = value; }
        public int SpecNoOfFemaleStudents { get => specNoOfFemaleStudents; set => specNoOfFemaleStudents = value; }
        public string SpecLanguageOfStudy { get => specLanguageOfStudy; set => specLanguageOfStudy = value; }
        public int Id { get => id; set => id = value; }
    }
}
