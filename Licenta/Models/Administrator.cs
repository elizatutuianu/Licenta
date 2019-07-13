using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.Models
{
    public class Administrator
    {
        private DateTime? ddlRegistration;
        private DateTime? ddlFinishProcess;

        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = @"{MM-dd-yyyy HH:mm}")]
        [DataType(DataType.Date)]
        public DateTime? DdlRegistration { get => ddlRegistration; set => ddlRegistration = value; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{MM-dd-yyyy HH:mm}")]
        [DataType(DataType.Date)]
        public DateTime? DdlFinishProcess { get => ddlFinishProcess; set => ddlFinishProcess = value; }
    }
}
