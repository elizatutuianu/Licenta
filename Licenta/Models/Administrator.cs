using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Administrator : User
    {
        //private int id;
        private DateTime ddlRegistration;
        private DateTime ddlFinishProcess;

        public DateTime DdlRegistration { get => ddlRegistration; set => ddlRegistration = value; }
        public DateTime DdlFinishProcess { get => ddlFinishProcess; set => ddlFinishProcess = value; }
        //public int Id { get => id; set => id = value; }

        //public Administrator(DateTime ddlRegistration, DateTime ddlFinishProcess, string email, string pass, string confirmPass, bool isAdmin = true)
        //    : base(email, pass, confirmPass, isAdmin)
        //{
        //    this.ddlRegistration = ddlRegistration;
        //    this.ddlFinishProcess = ddlFinishProcess;
        //}

    }
}
