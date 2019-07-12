using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class AccountController : Controller
    {
        private readonly Repository _repository;

        public AccountController(Repository repository)
        { 
            _repository = repository;
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(Student model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.message = _repository.RegisterStudent(model);
                _repository.SaveAll();
            }
            return RedirectToAction("Login","App");

        }
    }
}