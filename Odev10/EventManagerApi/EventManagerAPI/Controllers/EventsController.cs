using Microsoft.AspNetCore.Mvc;
using EventManagerAPI.Models;

namespace EventManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateEvent([FromBody] Event newEvent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            return Ok(newEvent);
        }
    }
}