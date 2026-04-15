using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
          return Ok(DataHandler.Roomdata);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            Room tmp = null;
            foreach(Room r in DataHandler.Roomdata)
                if (r.Id == id)
                    tmp = r;

            if (tmp != null)
                return Ok(tmp);
            
            return NotFound();
        }
    }
}
