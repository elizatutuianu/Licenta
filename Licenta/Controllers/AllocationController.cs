using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class AllocationController : Controller
    {
        private readonly Repository _repository;
        public int noBedsAvailableInTotal;

        public AllocationController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Allocation()
        {
            if (_repository.GetAllDorms().Any()
                && DeadlinesAdminController.administrator != null
                && _repository.GetAllFaculties().Any()
                && _repository.GetAllIdCardStudents().Any()
                && _repository.GetAllSpecializations().Any()
                && _repository.GetAllStudents().Any())
            {
                //DeadlinesAdminController.administrator
                noBedsAvailableInTotal = _repository.GetAllAvailableBeds();
                return null;
            }
            @ViewBag.ErrorMessage = "You must follow the previous steps before start!";
            return RedirectToAction("HomePageAdmin", "Admin");
        }
    }
}