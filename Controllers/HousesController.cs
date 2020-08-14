using System.Collections.Generic;
using System.Security.Claims;
using fullstack_gregslist.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace fullstack_gregslist.Controllers
{
  [ApiController]
  [Route("Api/[Controller]")]

  public class HousesController : ControllerBase
  {
    private readonly HousesService _hs;

    public HousesController(HousesService hs)
    {
      _hs = hs;
    }
    [HttpGet]
    public ActionResult<IEnumerable<House>> Get()
    {
      try
      {
        return Ok(_hs.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("user")]
    [Authorize]
    public ActionResult<IEnumerable<House>> GetByUserId()
    {
      try
      {
        string UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_hs.GetByUserId(UserId));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpGet("{Id}")]
    [Authorize]
    public ActionResult<House> GetByHouseId(int id)
    {
      try
      {
        return Ok(_hs.GetByHouseId(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpPost]
    [Authorize]
    public ActionResult<House> create([FromBody] House newHouse)
    {
      try
      {
        newHouse.UserId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_hs.Creat(newHouse));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpPut("{Id}")]
    [Authorize]
    public ActionResult<House> Edit(int id [FromBody] House houseToUpdate)
    {
      try
      {
        houseToUpdate.Id = id;
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_hs.edit(houseToUpdate, userId));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
    [HttpDelete("{Id}")]
    [Authorize]
    public ActionResult<House> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_hs.delete(id, userId));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}