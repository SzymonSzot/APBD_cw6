using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
          return Ok("Rooms");
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok("Rooms"+id);
        }
    }
}
