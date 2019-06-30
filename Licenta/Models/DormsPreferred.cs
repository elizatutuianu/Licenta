using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class DormsPreferred
    {
        [Key]
        public int Id { get; set; }
        public int AccomodationRequestId { get; set; }
        public AccomodationRequest AccomodationRequest { get; set; }
        public int DormId { get; set; }
        public Dorm Dorm { get; set; }
    }
}
