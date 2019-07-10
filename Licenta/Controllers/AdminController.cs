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
    public class AdminController : Controller
    {
        private readonly Repository _repository;

        public AdminController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet("HomePageAdmin")]
        public IActionResult HomePageAdmin()
        {
            return View();
        }

        [HttpPost("HomePageAdmin")]
        public IActionResult HomePageAdmin([FromBody]Dorm model)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateDorm(model);
                if (_repository.SaveAll())
                    return Created($"dorms/{model.Id}", model);
            }

            return View();
        }

        [HttpGet("GetDorms")]
        public ActionResult<IEnumerable<Student>> GetDorms()
        {
            try
            {
                return Ok(_repository.GetAllDorms());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get dorms");
            }
        }

        [HttpGet("GetRooms")]
        public ActionResult<IEnumerable<Student>> GetRooms()
        {
            try
            {
                return Ok(_repository.GetAllRooms());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get rooms");
            }
        }

        [HttpGet("CountRooms")]
        public int GetRoomsNo()
        {
            try
            {
                return _repository.GetAllRooms().Count();
            }
            catch (Exception ex)
            {
            }
            return -1;
        }
    }
}