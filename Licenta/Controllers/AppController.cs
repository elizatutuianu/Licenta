using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Licenta.Models;
using Licenta.Data;
using Microsoft.AspNetCore.Http;

namespace Licenta.Controllers
{
    public class AppController : Controller
    {
        private readonly DBContext _context;
        private readonly Repository _repository;
        public static Student student;

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
            
            if (user != null)
                if (user.Email == "admin@a.ro" && user.Password == "123Admin!")
                    return RedirectToAction("HomePageAdmin", "Admin");
                else
                {
                    student = _repository.VerifyStudent(user);
                    //ViewBag.Student = (Student)u;
                    //int id = u.Id;
                    //TempData["id"] = u.Id;
                    return RedirectToAction("HomePageStudent", "HomePageStudent");
                    //return View("/AccomodationRequest/HomePageStudent", (Student)u);
                }
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
