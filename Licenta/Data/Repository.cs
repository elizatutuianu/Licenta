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
            if (u == null)
                return null;
            u.Faculty = db.Faculties.FirstOrDefault(item => item.Id == u.FacultyId);
            u.Specialization = db.Specializations.FirstOrDefault(item => item.Id == u.SpecializationId);
            return u;
        }

        public void InsertStudent(Student student)
        {
            db.Students.Add(student);
        }

        public void InsertIdCard(IdCardStudent idCard)
        {
            db.IdCardStudents.Add(idCard);
        }

        public void InsertFaculty(Faculty faculty)
        {
            db.Faculties.Add(faculty);
        }

        public void InsertSpecialization(Specialization specialization)
        {
            db.Specializations.Add(specialization);
        }

        public Faculty GetFacultyByName(string name)
        {
            return db.Faculties.FirstOrDefault(item => item.Name == name);
        }

        public Specialization GetSpecializationByName(string name)
        {
            return db.Specializations.FirstOrDefault(item => item.SpecName == name);
        }

        public IdCardStudent GetIdCardStudentByNumber(string number)
        {
            return db.IdCardStudents.FirstOrDefault(item => item.IdCardNo == number);
        }

        public IdCardStudent GetIdCardStudentById(int id)
        {
            return db.IdCardStudents.FirstOrDefault(item => item.Id == id);
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

        public String RegisterStudent(Student model)
        {
            var student = db.Students.FirstOrDefault(item => item.Cnp == model.Cnp);
            if (student != null && student.Email.Length == 0)
            {
                student.Email = model.Email;
                student.Password = model.Password;
                student.ConfirmPassword = model.ConfirmPassword;
                db.Students.Update(student);
                return "Success!";
            }
            return "Already have an account!";
        }

        public void CreateDorm(Dorm model)
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

        public IEnumerable<Faculty> GetAllFaculties()
        {
            return db.Faculties
                      .OrderBy(s => s.Id)
                      .ToList();
        }

        public IEnumerable<Specialization> GetAllSpecializations()
        {
            return db.Specializations
                      .OrderBy(s => s.Id)
                      .ToList();
        }

        public IEnumerable<IdCardStudent> GetAllIdCardStudents()
        {
            return db.IdCardStudents
                      .OrderBy(s => s.Id)
                      .ToList();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return db.Students
                      .OrderBy(s => s.Id)
                      .ToList();
        }

        public IEnumerable<Dorm> GetAllDorms()
        {
            return db.Dorms
                      .OrderBy(s => s.Id)
                      .ToList();
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

        //Calculate available beds

        public int GetAllAvailableBeds()
        {
            int bedsInTotal = 0;
            IEnumerable<Dorm> dorms = /*(List<Dorm>)*/GetAllDorms();
            foreach (Dorm dorm in dorms)
            {
                bedsInTotal += dorm.DormBedsInRoom * dorm.DormNoRooms;
            }
            return bedsInTotal;
        }

        public int GetStudentsFromProvinciePerFaculty(string facultyName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Faculty.Name == facultyName).ToList().Count;
        }

        public int GetStudentsFromProvinciePerSpecializationInFirstYear(string specializationName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Specialization.SpecName == specializationName && stud.Year == 1).ToList().Count;
        }

        public int GetStudentsFromProvinciePerSpecializationInFirstYearSpecial(string specializationName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Specialization.SpecName == specializationName && stud.Year == 1 && (stud.IsMedicalCase == true || stud.IsSocialCase == true)).ToList().Count;
        }

        public int GetStudentsFromProvinciePerSpecializationInSecondYear(string specializationName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Specialization.SpecName == specializationName && stud.Year == 2).ToList().Count;
        }

        public int GetStudentsFromProvinciePerSpecializationInSecondYearSpecial(string specializationName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Specialization.SpecName == specializationName && stud.Year == 2 && (stud.IsMedicalCase == true || stud.IsSocialCase == true)).ToList().Count;
        }

        public int GetStudentsFromProvinciePerSpecializationInThirdYear(string specializationName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Specialization.SpecName == specializationName && stud.Year == 3).ToList().Count;
        }

        public int GetStudentsFromProvinciePerSpecializationInThirdYearSpecial(string specializationName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Specialization.SpecName == specializationName && stud.Year == 3 && (stud.IsMedicalCase == true || stud.IsSocialCase == true)).ToList().Count;
        }

        public int GetStudentsFromProvincie()
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti").ToList().Count;
        }

        public int GetStudentsInFirstYearStudentPerFaculty(string facultyName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Faculty.Name == facultyName && stud.Year == 1).ToList().Count;
        }

        public int GetStudentsInSecondYearStudentPerFaculty(string facultyName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Faculty.Name == facultyName && stud.Year == 2).ToList().Count;
        }

        public int GetStudentsInThirdYearStudentPerFaculty(string facultyName)
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Faculty.Name == facultyName && stud.Year == 3).ToList().Count;
        }

        public int GetStudentsFromFirstYear()
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Year.Equals(1)).ToList().Count();
        }
        public int GetStudentsFromSecondYear()
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Year == 2).ToList().Count();
        }
        public int GetStudentsFromThirdYear()
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti" && stud.Year == 3).ToList().Count();
        }

        public int GetStudentsFromProv()
        {
            return db.Students.Where(stud => stud.IdCardStudent.District != "Bucuresti").Count();
        }

        public void UpdateIdCardStudent(Student student, IdCardStudent idCardNew)
        {
            IdCardStudent idCardOld = db.IdCardStudents.FirstOrDefault(item => item.Id == student.IdCardStudentId);
            idCardOld.IdCardNo = idCardNew.IdCardNo;
            idCardOld.IdCardIssuedBy = idCardNew.IdCardIssuedBy;
            idCardOld.IdCardIssuedDate = idCardNew.IdCardIssuedDate;
            idCardOld.Country = idCardNew.Country;
            idCardOld.District = idCardNew.District;
            idCardOld.Localty = idCardNew.Localty;
            idCardOld.Address = idCardNew.Address;
            idCardOld.CivilStatus = idCardNew.CivilStatus;
            db.IdCardStudents.Update(idCardOld);
        }

        public void DeleteDorm(int id)
        {
            IEnumerable<Room> rooms = db.Rooms.Where(item => item.DormId == id);
            foreach (Room room in rooms)
                db.Remove(room);
            db.Remove(db.Dorms.Find(id));
        }
    }
}
