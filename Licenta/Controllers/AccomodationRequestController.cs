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

        //[HttpPost("AccReq")]
        //public IActionResult HomePageStudent([FromBody]AccomodationRequest model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _repository.CreateAccomodationRequest(model);
        //            if (_repository.SaveAll())
        //            {
        //                return Created($"accomodationrequest/{model.Id}", model);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }

        //    return View();
        //}

        [HttpGet("GetAccomodationRequests")]
        public ActionResult<IEnumerable<AccomodationRequest>> GetAccomodationRequests()
        {
            try
            {
                return Ok(_repository.GetAllAccRequests());
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get accomodation requests");
            }
        }
    }
}