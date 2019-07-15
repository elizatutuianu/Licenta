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
            Student stud= _repository.GetStudentByCNP(AppController.student.Cnp);
            if (stud.AccomodationRequestId.HasValue)
            {
                TempData["mess"] = "Accomodation request already sent!";
                return RedirectToAction("HomePageStudent", "HomePageStudent");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Preferences(AccomodationRequest accomodationRequest)
        {
            Student stud = _repository.GetStudentByCNP(AppController.student.Cnp);
            if (!stud.AccomodationRequestId.HasValue)
            {
                _repository.AddAccomodationRequest(accomodationRequest, AppController.student);
                _repository.SaveAll();
                TempData["mess"] = "Accomodation request sent!";
            }
            else
            {
                TempData["mess"] = "Accomodation request already sent!";
            }
            return RedirectToAction("HomePageStudent", "HomePageStudent");
        }


    }
}
