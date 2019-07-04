using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Licenta.Controllers
{
    public class PreferencesController : Controller
    {
        private readonly Repository _repository;

        public PreferencesController(Repository repository)
        {
            _repository = repository;
        }
        
        public IActionResult Preferences()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Preferences(AccomodationRequest accomodationRequest)
        {
            if (ModelState.IsValid)
            {
                _repository.AddAccomodationRequest(accomodationRequest, HomePageStudentController.student);
                _repository.SaveAll();
            }
            return View();
        }

        
    }
}
