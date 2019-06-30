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

        public bool VerifyStudent(User user)
        {
            var u = db.Students.FirstOrDefault(item => item.Email == user.Email && item.Password == user.Password);
            if (u != null)
            {
                return true;
            }
            return false;
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

        //public void CreateAccomodationRequest(AccomodationRequest model)
        //{
        //    try
        //    {
        //        AccomodationRequest ar = new AccomodationRequest();
        //        if (model.ArDorm != null)
        //        {
        //            ar.ArDorm = new List<Dorm>();
        //            ar.ArRoom = new List<Room>();
        //            int sizeArrayDorms = model.ArDorm.Count();
        //            Dorm dorm;
        //            Room room;
        //            for (int i = 0; i < sizeArrayDorms; i++)
        //            {
        //                dorm = db.Dorms.FirstOrDefault(item => item.DormName == model.ArDorm[i].DormName);
        //                if (dorm.AccomodationRequestId == null)
        //                    ar.ArDorm.Add(dorm);
        //                else
        //                {
        //                    Dorm newDorm = new Dorm();
        //                    newDorm.DormBedsInRoom = dorm.DormBedsInRoom;
        //                    newDorm.DormComfort = dorm.DormComfort;
        //                    newDorm.DormGender = dorm.DormGender;
        //                    newDorm.DormName = dorm.DormName;
        //                    newDorm.DormNoRooms = dorm.DormNoRooms;
        //                    newDorm.IsDormForRomanians = dorm.IsDormForRomanians;
        //                    newDorm.AccomodationRequestId = ar.Id;
        //                    ar.ArDorm.Add(newDorm);
        //                }
        //                if (i + 1 <= model.ArRoom.Count())
        //                {
        //                    room = db.Rooms.Where(item => item.DormId == dorm.Id && item.RoomNo == model.ArRoom[i].RoomNo).FirstOrDefault();
        //                    if (room.AccomodationRequestId == null)
        //                        ar.ArRoom.Add(room);
        //                    else
        //                    {
        //                        Room newRoom = new Room();
        //                        newRoom.BedsInRoom = room.BedsInRoom;
        //                        newRoom.DormId = room.DormId;
        //                        newRoom.RoomGender = room.RoomGender;
        //                        newRoom.RoomNo = room.RoomNo;
        //                        newRoom.StudentsInRoom = room.StudentsInRoom;
        //                        newRoom.AccomodationRequestId = ar.Id;
        //                        ar.ArRoom.Add(newRoom);
        //                    }
        //                }
        //                //else show message room doesn t exist
        //            }
        //            ar.LastComfortAccepted = model.LastComfortAccepted;
        //        }
        //        else
        //            ar.LastComfortAccepted = 5;
        //        db.AccomodationRequests.Add(ar);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

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
    }
}
