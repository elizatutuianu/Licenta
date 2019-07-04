using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class DormsPreferred
    {
        [Key]
        public int Id { get; set; }
        public int? AccomodationRequestId { get; set; }
        [ForeignKey("AccomodationRequestId")]
        public AccomodationRequest AccomodationRequest { get; set; }
        public int? DormId { get; set; }
        [ForeignKey("DormId")]
        public Dorm Dorm { get; set; }
        [StringRange(AllowableValues = new[] { "Moxa", "Belvedere nou", "Belvedere vechi", "Tei", "Agronomie" }, ErrorMessage = "This dorm does not exist.")]
        public string DormName { get; set; }
    }

    internal class StringRangeAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Please enter one of the allowable values: {string.Join(", ", (AllowableValues ?? new string[] { "No allowable values found" }))}.";
            return new ValidationResult(msg);
        }
    }
}
