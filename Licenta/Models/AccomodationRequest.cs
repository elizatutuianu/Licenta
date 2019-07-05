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
        private string lastComfortAccepted;
        private List<Roommate> arRoommates = new List<Roommate>();

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LastComfortAccepted { get => lastComfortAccepted; set => lastComfortAccepted = value; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public List<Roommate> ArRoommates { get => arRoommates; set => arRoommates = value; }
        public int Id { get => id; set => id = value; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public List<DormsPreferred> ArDorm { get => arDorm; set => arDorm = value; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public List<RoomPreferred> ArRoom { get => arRoom; set => arRoom = value; }
    }
}
