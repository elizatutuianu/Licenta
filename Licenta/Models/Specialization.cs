using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Specialization
    {
        private string specName;
        private int specNoOfStudents;
        private int specNoOfFemaleStudents;
        private string specLanguageOfStudy;

        public string SpecName { get => specName; set => specName = value; }
        public int SpecNoOfStudents { get => specNoOfStudents; set => specNoOfStudents = value; }
        public int SpecNoOfFemaleStudents { get => specNoOfFemaleStudents; set => specNoOfFemaleStudents = value; }
        public string SpecLanguageOfStudy { get => specLanguageOfStudy; set => specLanguageOfStudy = value; }

        public Specialization(string specName, int specNoOfStudents, int specNoOfFemaleStudents, string specLanguageOfStudy)
        {
            SpecName = specName;
            SpecNoOfStudents = specNoOfStudents;
            SpecNoOfFemaleStudents = specNoOfFemaleStudents;
            SpecLanguageOfStudy = specLanguageOfStudy;
        }
    }
}
