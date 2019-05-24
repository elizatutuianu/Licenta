using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Faculty
    {
        [Key]
        private int id;
        private string name;
        private List<Specialization> specializations;

        public string Name { get => name; set => name = value; }
        public List<Specialization> Specializations { get => specializations; set => specializations = value; }
        public int Id { get => id; set => id = value; }
        //public Faculty(string name, List<Specialization> specializations)
        //{
        //    Name = name;
        //    Specializations = new List<Specialization>();
        //    foreach (Specialization specialization in specializations)
        //        Specializations.Add(specialization);

        //}
    }
}
