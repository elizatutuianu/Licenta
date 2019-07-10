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
            //admin.Email = "admin@a.ro";
            //admin.Password = "123Admin!";
            //admin.ConfirmPassword = "123Admin!";
            if (ModelState.IsValid)
            {
                return RedirectToAction("HomePageAdmin", "Admin");
            }
            return View();
        }
    }
}