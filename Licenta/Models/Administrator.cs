using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Administrator : User
    {
        private DateTime ddlRegistration;
        private DateTime ddlFinishProcess;

        public DateTime DdlRegistration { get => ddlRegistration; set => ddlRegistration = value; }
        public DateTime DdlFinishProcess { get => ddlFinishProcess; set => ddlFinishProcess = value; }
    }
}
