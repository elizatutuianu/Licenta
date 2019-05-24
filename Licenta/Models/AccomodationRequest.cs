using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class AccomodationRequest
    {
        [Key]
        private int id;
        private List<Dorm> arDorm = new List<Dorm>();
        private List<Room> arRoom = new List<Room>();
        private List<Student> arRoommates = new List<Student>();
        private int arConfort;

        public List<Student> ArRoommates { get => arRoommates; set => arRoommates = value; }
        public int ArConfort { get => arConfort; set => arConfort = value; }
        public List<Dorm> ArDorm { get => arDorm; set => arDorm = value; }
        public List<Room> ArRoom { get => arRoom; set => arRoom = value; }
        public int Id { get => id; set => id = value; }

        //public AccomodationRequest(List<Tuple<Dorm, Room>> arDormRooms, List<Student> arRoommates, int arConfort)
        //{
        //    ArDormRooms = arDormRooms;
        //    ArRoommates = arRoommates;
        //    ArConfort = arConfort;
        //}

    }
}
