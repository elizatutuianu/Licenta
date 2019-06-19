using System.ComponentModel.DataAnnotations;

namespace Licenta.Models
{
    public class Roommate
    {
        [Key]
        public int Id { get; set; }
        public int AccomodationRequestId { get; set; }
        public AccomodationRequest AccomodationRequest { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}