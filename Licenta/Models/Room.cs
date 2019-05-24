using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Room
    {
        [Key]
        private int id;
        private int roomNo;
        private string roomGender;
        private int bedsInRoom;
        private List<Student> studentsInRoom = new List<Student>();

        public int RoomNo { get => roomNo; set => roomNo = value; }
        public string RoomGender
        {
            get => roomGender;
            set
            {
                if (this.RoomGender == null)
                    roomGender = value;
            }
        }
        public List<Student> StudentsInRoom
        {
            get => studentsInRoom;
            set
            {
                if (value.Count <= BedsInRoom)
                    studentsInRoom = value;
                else
                    throw new Exception("Too many students for this room");
            }
        }
        public int BedsInRoom { get => bedsInRoom; set => bedsInRoom = value; }
        public int Id { get => id; set => id = value; }

        //public Room(int roomNo, string roomGender, List<Student> studentsInRoom)
        //{
        //    RoomNo = roomNo;
        //    RoomGender = roomGender;
        //    StudentsInRoom = studentsInRoom;
        //}
    }
}
