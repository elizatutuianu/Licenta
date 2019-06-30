using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Licenta.Data;
using Licenta.Models;
using Microsoft.AspNetCore.Mvc;

namespace Licenta.Controllers
{
    //[Route("[controller]")]
    //[ApiController]
    public class AccountController : Controller
    {
        private readonly Repository _repository;
        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;

        public AccountController(Repository repository)//, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _repository = repository;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        [HttpGet("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("Register")]
        public IActionResult Register(Student model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.message = _repository.UpdateStudent(model);
                _repository.SaveAll();
                //return ;
                //Created($"students/{model.Id}", model);
                //return RedirectToAction("Login", "App");
                //} 
                
            }
            return RedirectToAction("Login","App");

        }
    }
}