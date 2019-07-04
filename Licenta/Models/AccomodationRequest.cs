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
        private List<DormsPreferred> arDorm = new List<DormsPreferred>();
        private List<RoomPreferred> arRoom = new List<RoomPreferred>();
        private int lastComfortAccepted;
        private List<Roommate> arRoommates = new List<Roommate>();

        public int LastComfortAccepted { get => lastComfortAccepted; set => lastComfortAccepted = value; }
        public List<Roommate> ArRoommates { get => arRoommates; set => arRoommates = value; }
        public int Id { get => id; set => id = value; }
        public List<DormsPreferred> ArDorm { get => arDorm; set => arDorm = value; }
        public List<RoomPreferred> ArRoom { get => arRoom; set => arRoom = value; }
    }
}
