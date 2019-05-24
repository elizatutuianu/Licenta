using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class IdCardStudent
    {
        [Key]
        private int id;
        private string idCardNo;
        private string idCardIssuedBy;
        private DateTime idCardIssuedDate;
        private string country;
        private string district;
        private string localty;
        private string address;
        private string civilStatus;
        private DateTime birthDate;

        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Country { get => country; set => country = value; }
        public string IdCardNo { get => idCardNo; set => idCardNo = value; }
        public string IdCardIssuedBy { get => idCardIssuedBy; set => idCardIssuedBy = value; }
        public DateTime IdCardIssuedDate { get => idCardIssuedDate; set => idCardIssuedDate = value; }
        public string District { get => district; set => district = value; }
        public string Localty { get => localty; set => localty = value; }
        public string Address { get => address; set => address = value; }
        public string CivilStatus { get => civilStatus; set => civilStatus = value; }
        public int Id { get => id; set => id = value; }
    }
}
