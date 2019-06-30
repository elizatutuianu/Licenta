using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Licenta.Models;
using Licenta.Data;

namespace Licenta.Controllers
{
    public class AppController : Controller
    {
        private readonly DBContext _context;
        private readonly Repository _repository;

        public AppController(DBContext context, Repository repo)
        {
            this._context = context;
            this._repository = repo;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginGet(User user)
        {
            //var u = user;
            //u.ConfirmPassword = u.Password;
            //if (ModelState.IsValid)
            //{
            if (_repository.VerifyStudent(user))
                if (user.Email == "admin@a.ro" && user.Password == "123Admin!")
                    return RedirectToAction("HomePageAdmin", "Admin");
                else
                    return RedirectToAction("HomePageStudent", "AccomodationRequest");
            //}
            return View();
        }

        [HttpGet("/app/getstudents")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return Ok(_repository.GetAllStudents());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get students");
            }
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "App");
        }

        //[HttpPost("/app/homepageadmin")]
        //public IActionResult HomePageAdmin(Dorm dorm)
        //{
        //    if(ModelState.IsValid)
        //    {

        //    }
        //    return View();
        //}
    }
}
