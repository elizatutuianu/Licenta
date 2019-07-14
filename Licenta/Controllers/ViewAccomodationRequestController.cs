using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class ViewAccomodationRequestController : Controller
    {
        private readonly Repository _repository;
        public ViewAccomodationRequestController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult ViewAccomodationRequest()
        {
            Student student = _repository.GetStudentById(AppController.student.Id);
            if (student.AccomodationRequestId != null)
            {
                AccomodationRequest accomodationRequest = _repository.GetAccomodationRequestById((int)student.AccomodationRequestId);
                return View(accomodationRequest);
            }
            else
            {
                TempData["mess"] = "You have not sent an accomodation request yet!";
                return RedirectToAction("HomePageStudent", "HomePageStudent");
            }
            
            
        }
    }
}