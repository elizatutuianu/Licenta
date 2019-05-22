using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Licenta.Models;

namespace Licenta.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("register")]
        public IActionResult Register(Student student)
        {
            if(ModelState.IsValid)
            {

            }
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult HomePageStudent()
        {
            return View();
        }

        [HttpGet("/app/homepageadmin")]
        public IActionResult HomePageAdmin()
        {
            return View();
        }

        [HttpPost("/app/homepageadmin")]
        public IActionResult HomePageAdmin(Dorm dorm)
        {
            if(ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
