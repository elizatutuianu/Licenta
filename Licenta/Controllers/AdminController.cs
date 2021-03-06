﻿using System;
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
    public class AdminController : Controller
    {
        private readonly Repository _repository;

        public AdminController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult HomePageAdmin()
        {
            ViewBag.ErrorMessage = TempData["error"];
            return View(_repository.GetAllDorms());
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _repository.DeleteDorm(id);
                _repository.SaveAll();
            }
            return RedirectToAction("HomePageAdmin", "Admin");
        }

    }
}