using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Camin
    {
        private string dormName;
        private int dormComfort;
        private int dormNoRooms;
        private int dormBedsInRoom;
        private string dormGender;
        private bool isDormForRomanians;

        [Required(ErrorMessage = "You need to complete")]
        [MinLength(3)]
        public string DormName { get => dormName; set => dormName = value; }

        [Required(ErrorMessage = "You need to complete")]
        [MinLength(1)]
        [MaxLength(1)]
        [Range(1, 5, ErrorMessage = "Please enter valid number for comfort(1 to 5)")]
        public int DormComfort { get => dormComfort; set => dormComfort = value; }

        [Required(ErrorMessage = "You need to complete")]
        [Range(10, int.MaxValue, ErrorMessage = "Please enter valid number (minimum 10 rooms)")]
        public int DormNoRooms { get => dormNoRooms; set => dormNoRooms = value; }

        [Required(ErrorMessage = "You need to complete")]
        [Range(1, 5, ErrorMessage = "Please enter valid number (1 to 5 beds in room)")]
        public int DormBedsInRoom { get => dormBedsInRoom; set => dormBedsInRoom = value; }

        [Required(ErrorMessage ="You need to complete")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "This field must be 1 char (G (Girls), B (Boys), M (Mixed))")]
        public string DormGender { get => dormGender; set => dormGender = value; }

        [Required(ErrorMessage = "You need to complete")]
        public bool IsDormForRomanians { get => isDormForRomanians; set => isDormForRomanians = value; }
    }
}
