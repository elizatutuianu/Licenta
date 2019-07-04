using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Licenta.Models
{
    public class Roommate
    {
        [Key]
        public int Id { get; set; }
        public int AccomodationRequestId { get; set; }
        [ForeignKey("AccomodationRequestId")]
        public AccomodationRequest AccomodationRequest { get; set; }
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
    }
}