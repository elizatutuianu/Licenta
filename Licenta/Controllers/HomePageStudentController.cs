﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    public class HomePageStudentController : Controller
    {
        private readonly Repository _repository;

        public HomePageStudentController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("HomePageStudent")]
        public IActionResult HomePageStudent()
        {
            ViewBag.AlreadySentRequest = TempData["mess"] != null ? TempData["mess"].ToString() : string.Empty;
            return View(AppController.student);
        }

    }
}