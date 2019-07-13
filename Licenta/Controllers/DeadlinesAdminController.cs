using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class DeadlinesAdminController : Controller
    {
        private readonly Repository _repository;
        public Administrator administrator = new Administrator();

        public DeadlinesAdminController(Repository repository)
        {
            _repository = repository;
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
            return View();
        }
    }
}