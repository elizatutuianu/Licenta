using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class AccomodationRequest
    {
        private List<Tuple<Dorm, Room>> arDormRooms;
        private List<Student> arRoommates;
        private int arConfort;

        public List<Tuple<Dorm, Room>> ArDormRooms { get => arDormRooms; set => arDormRooms = value; }
        public List<Student> ArRoommates { get => arRoommates; set => arRoommates = value; }
        public int ArConfort { get => arConfort; set => arConfort = value; }

        public AccomodationRequest(List<Tuple<Dorm, Room>> arDormRooms, List<Student> arRoommates, int arConfort)
        {
            ArDormRooms = arDormRooms;
            ArRoommates = arRoommates;
            ArConfort = arConfort;
        }
        
    }
}
