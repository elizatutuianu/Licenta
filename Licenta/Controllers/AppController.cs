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
        private readonly DBContext context;
        private readonly Repository _repository;

        public AppController(DBContext context)
        {
            this.context = context;
        }

        [HttpGet("/app/getstudents")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            try
            {
                var list = context.Students
                          .OrderBy(s => s.Id)
                          .ToList();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get students");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
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
