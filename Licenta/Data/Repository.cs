using Licenta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Data
{
    public class Repository
    {
        private readonly DBContext db;
        public Repository(DBContext context)
        {
            db = context;
        }

        //save
        public bool SaveAll()
        {
            return db.SaveChanges() > 0;
        }

        //update
        public void UpdateStudent(Student model)
        {
            var student = db.Students.FirstOrDefault(item => item.Cnp == model.Cnp);
            if (student != null)
            {
                student.Email = model.Email;
                student.Password = model.Password;
                db.Students.Update(student);
            }
        }

        public IEnumerable<Student> GetAllStudents()
        {
            try
            {
                return db.Students
                          .OrderBy(s => s.Id)
                          .ToList(); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
