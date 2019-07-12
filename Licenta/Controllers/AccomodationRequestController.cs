using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccomodationRequestController : Controller
    {
        private readonly Repository _repository;

        public AccomodationRequestController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult AccomodationRequest()
        {
            if (!AppController.student.AccomodationRequestId.HasValue)
            {
                AccomodationRequest accomodation = new AccomodationRequest();
                _repository.AddAccomodationRequest(accomodation, AppController.student);
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