using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class AddDormController : Controller
    {
        private readonly Repository _repository;

        public AddDormController(Repository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public IActionResult AddDorm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDorm(Dorm model)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateDorm(model);
                if (_repository.SaveAll()) ;
                return RedirectToAction("HomePageAdmin", "Admin");

            }
            return View();
        }
    }
}