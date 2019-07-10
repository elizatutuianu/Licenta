using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Dorm
    {
        [Key]
        private int id;
        private string dormName;
        private int dormComfort;
        private int dormNoRooms;
        private int dormBedsInRoom;
        private string dormGender;
        private bool isDormForRomanians;
        private List<Room> rooms = new List<Room>();
        public bool IsFull { get; set; }


        [Required(ErrorMessage = ResourcesStrings.REQUIRED)]
        [MinLength(3)]
        public string DormName { get => dormName; set => dormName = value; }
        public int DormComfort { get => dormComfort; set => dormComfort = value; }
        public int DormNoRooms { get => dormNoRooms; set => dormNoRooms = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }
        public string DormGender { get => dormGender; set => dormGender = value; } //F,M,Mixt
        public bool IsDormForRomanians { get => isDormForRomanians; set => isDormForRomanians = value; }
        public int Id { get => id; set => id = value; }
        public int DormBedsInRoom { get => dormBedsInRoom; set => dormBedsInRoom = value; }
    }
}
