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

        public Student VerifyStudent(User user)
        {
            var u = db.Students.FirstOrDefault(item => item.Email == user.Email && item.Password == user.Password);
            u.Faculty = db.Faculties.FirstOrDefault(item => item.Id == u.FacultyId);
            u.Specialization = db.Specializations.FirstOrDefault(item => item.Id == u.SpecializationId);
            return u;
        }

        public User GetUserByEmail(string email)
        {
            var u = db.Students.FirstOrDefault(item => item.Email == email);
            if (u == null)
                return null;
            u.Faculty = db.Faculties.FirstOrDefault(item => item.Id == u.FacultyId);
            u.Specialization = db.Specializations.FirstOrDefault(item => item.Id == u.SpecializationId);
            return u;
        }

        public String UpdateStudent(Student model)
        {
            var student = db.Students.FirstOrDefault(item => item.Cnp == model.Cnp);
            if (student != null && student.Email == null)
            {
                student.Email = model.Email;
                student.Password = model.Password;
                student.ConfirmPassword = model.ConfirmPassword;
                db.Students.Update(student);
                return "Success!";
            }
            return "Already have an account!";
        }

        public int CheckStudentInDb(Student student)
        {
            try
            {
                Student stud = db.Students.FirstOrDefault(item => item.FirstName == student.FirstName
                && item.LastName == student.LastName
                && item.Initial == student.Initial
                && item.Specialization.SpecName == student.Specialization.SpecName
                && item.Faculty.Name == student.Faculty.Name
                && item.Year == student.Year
                && item.StudyProgram == student.StudyProgram);
                if (stud != null)
                {
                    return stud.Id;
                }
            }
            catch (Exception ex)
            {

            }
            return -1;
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
                for (int i = 0; i < model.DormNoRooms; i++)
                {
                    room = new Room();
                    room.BedsInRoom = model.DormBedsInRoom;
                    if (model.DormGender != "Mixt")
                        room.RoomGender = model.DormGender;
                    room.RoomNo = i + 1;
                    dorm.Rooms.Add(room);
                    db.Rooms.Add(room);
                }
                db.Dorms.Add(dorm);
            }
            catch (Exception ex)
            {

            }
        }

        public void AddAccomodationRequest(AccomodationRequest model, Student student)
        {
            Student stud = db.Students.FirstOrDefault(item => item.Id == student.Id);
            if (stud.AccomodationRequestId == null)
            {
                foreach (Roommate roommate in model.ArRoommates)
                {
                    Student studentRoommate = db.Students.FirstOrDefault(item => item.FirstName == roommate.FirstName && item.LastName == roommate.LastName && item.Initial == roommate.Initial);
                    if (studentRoommate != null)
                    {
                        roommate.Student = studentRoommate;
                        roommate.StudentId = studentRoommate.Id;
                    }
                }
                stud.AccomodationRequest = model;
                db.AccomodationRequests.Add(model);
                db.Students.Update(stud);
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

        public IEnumerable<AccomodationRequest> GetAllAccRequests()
        {
            try
            {
                return db.AccomodationRequests
                          .OrderBy(s => s.Id)
                          .ToList(); ;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int ChangePassword(User user, string email)
        {
            Student u = db.Students.FirstOrDefault(item => item.Email == email);
            if (user.Password == user.ConfirmPassword && u != null)
            {
                u.Password = user.Password;
                u.ConfirmPassword = user.ConfirmPassword;
                db.Students.Update(u);
                return 1;
            }
            return 0;
        }
    }
}
