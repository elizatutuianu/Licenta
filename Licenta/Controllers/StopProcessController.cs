using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class StopProcessController : Controller
    {
        public StopProcessController()
        {

        }

        public IActionResult StopProcess()
        {
            DeadlinesAdminController.administrator.DdlFinishProcess = null;
            DeadlinesAdminController.administrator.DdlRegistration = null;
            return RedirectToAction("HomePageAdmin", "Admin");
        }
    }
}