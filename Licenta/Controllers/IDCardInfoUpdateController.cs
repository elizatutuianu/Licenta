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
    public class IDCardInfoUpdateController : Controller
    {
        private readonly Repository _repository;

        public IDCardInfoUpdateController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult IDCardInfoUpdate()
        {
            IdCardStudent idCard = _repository.GetIdCardStudentById(AppController.student.IdCardStudentId);
            return View(idCard);
        }

        [HttpPost]
        public IActionResult IDCardInfoUpdate(IdCardStudent idCardStudent)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateIdCardStudent(AppController.student, idCardStudent);
                _repository.SaveAll();
                TempData["mess"] = "Updated successfully!";
                return RedirectToAction("HomePageStudent", "HomePageStudent");
            }
            else
                ViewBag.ErrorUpdate = "Could not update! Try again!";
            return View();
            
        }
    }
}
