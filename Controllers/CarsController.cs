using System;
using System.Collections.Generic;
using System.Security.Claims;
using fullstack_gregslist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fullstack_gregslist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _cs;

        public CarsController(CarsService cs)
        {
            _cs = cs;
        }
        // NOTE path is https://localhost:5001/api/cars
        [HttpGet]
        public ActionResult<IEnumerable<Car>> GetAll()
        {
            try
            {
                return Ok(_cs.GetAll());
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // NOTE path is https://localhost:5001/api/cars/id
        [HttpGet("{id}")]
        public ActionResult<Car> GetById(int id)
        {
            try
            {
                return Ok(_cs.GetById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        //NOTE path does not follow standards https://localhost:5001/api/cars/user
        [Authorize]
        [HttpGet("user")]
        public ActionResult<IEnumerable<Car>> GetCarsByUser()
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("You must be logged in to get your cars!.");
                }
                string userId = user.Value;
                return Ok(_cs.GetByUserId(userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<Car> Edit(int id, [FromBody] Car carToUpdate)
        {
            try
            {
                carToUpdate.Id = id;
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("must be logged in");
                }
                string userId = user.Value;
                return Ok(_cs.Edit(carToUpdate, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult<Car> Create([FromBody] Car newCar)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("Must be logged in to create.");
                }
                newCar.UserId = user.Value;
                return Ok(_cs.Create(newCar));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("you must be logged in to delete");
                }
                string userId = user.Value;
                return Ok(_cs.Delete(id, userId));
            }
            catch (System.Exception error)
            {
                return BadRequest(error.Message);
            }
        }

    }
}