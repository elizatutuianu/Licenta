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

        public void CreateDorm(Dorm model)
        {
            try
            {
                Dorm dorm = new Dorm();
                Room room; 
                dorm.DormName = model.DormName;
                dorm.DormComfort = model.DormComfort;
                dorm.DormNoRooms = model.DormNoRooms;
                dorm.DormBedsInRoom = model.DormBedsInRoom;
                dorm.DormGender = model.DormGender;
                dorm.IsDormForRomanians = model.IsDormForRomanians;
                db.Dorms.Add(dorm);
                for (int i = 0; i < model.DormNoRooms; i++)
                {
                    room = new Room();
                    room.BedsInRoom = model.DormBedsInRoom;
                    if (model.DormGender != "Mixt")
                        room.RoomGender = model.DormGender;
                    room.RoomNo = i + 1;
                    db.Rooms.Add(room);
                }
            }
            catch(Exception ex)
            {

            }
        }

        public IEnumerable<Dorm> GetAllDorms()
        {
            try
            {
                return db.Dorms
                          .OrderBy(s => s.Id)
                          .ToList(); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Room> GetAllRooms()
        {
            try
            {
                return db.Rooms
                          .OrderBy(r => r.RoomNo)
                          .ToList(); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
