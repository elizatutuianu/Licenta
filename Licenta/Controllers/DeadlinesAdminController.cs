using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class DeadlinesAdminController : Controller
    {
        public static Administrator administrator;

        public DeadlinesAdminController()
        {
            administrator = new Administrator();
        }

        [HttpGet]
        public IActionResult DeadlinesAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeadlinesAdmin(Administrator admin)
        {
            if (ModelState.IsValid)
            {
                administrator.DdlRegistration = admin.DdlRegistration;
                administrator.DdlFinishProcess = admin.DdlFinishProcess;

                return RedirectToAction("HomePageAdmin", "Admin");
            }
            ViewBag.DeadlinesMessgage = "Wrong input. See format type!";
            return View();
        }


    }
}