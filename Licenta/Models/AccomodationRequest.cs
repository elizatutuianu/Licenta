﻿using System;
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
        private List<Dorm> arDorm = new List<Dorm>();
        private List<Room> arRoom = new List<Room>();
        private int lastComfortAccepted;
        private List<Roommate> arRoommates = new List<Roommate>();

        public int LastComfortAccepted { get => lastComfortAccepted; set => lastComfortAccepted = value; }
        public List<Roommate> ArRoommates { get => arRoommates; set => arRoommates = value; }
        public int Id { get => id; set => id = value; }
        public List<Dorm> ArDorm { get => arDorm; set => arDorm = value; }
        public List<Room> ArRoom { get => arRoom; set => arRoom = value; }
    }
}
