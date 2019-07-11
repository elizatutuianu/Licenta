using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Licenta.ViewModels
{
    public class ExcelFile
    {
        public IFormFile FileStudents { get; set; }
        public IFormFile FileIdCards { get; set; }
        public IFormFile FileFaculties { get; set; }
        public IFormFile FileSpecializations { get; set; }

    }
}
