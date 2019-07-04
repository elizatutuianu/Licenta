using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class RoomPreferred
    {
        [Key]
        public int Id { get; set; }
        public int? AccomodationRequestId { get; set; }
        [ForeignKey("AccomodationRequestId")]
        public AccomodationRequest AccomodationRequest { get; set; }
        public int? RoomId { get; set; }
        [ForeignKey("RoomId")]
        public Room Room { get; set; }
        public int RoomNo { get; set; }
    }
}
