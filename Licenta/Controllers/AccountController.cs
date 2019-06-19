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
    public class AccountController : Controller
    {
        private readonly Repository _repository;

        public AccountController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPut("register")]
        public IActionResult Register([FromBody]Student model)
        {
            try
            {
                _repository.UpdateStudent(model);
                if (_repository.SaveAll())
                {
                    ViewBag.errorMessage = "Registration completed!";
                    return Created($"students/{model.Id}", model);
                }
                else
                    ViewBag.errorMessage = "Account unavailable. You are not a student of ASE!";
            }
            catch (Exception ex)
            {
            }
            return View();
        }
    }
}