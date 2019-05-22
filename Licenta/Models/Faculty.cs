using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Faculty
    {
        private string name;
        private List<Specialization> specializations;

        public string Name { get => name; set => name = value; }
        public List<Specialization> Specializations { get => specializations; set => specializations = value; }
        public Faculty(string name, List<Specialization> specializations)
        {
            Name = name;
            Specializations = specializations;
        }
    }
}
