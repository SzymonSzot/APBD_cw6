using System.Collections;
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
        
        [HttpGet]
        [Route("{BuildingCode}")]
        public IActionResult GetAll([FromRoute] string? buildingCode)
        {
            ArrayList tmp = new ArrayList();
            foreach(Room r in DataHandler.Roomdata)
                if (r.BuildingCode == buildingCode)
                    tmp.Add(r);

            if (tmp.Count > 0)
                return Ok(tmp);
            
            return NotFound();
        }
        
        [HttpPost]
        public IActionResult CreateRoom([FromBody] Room newRoom)
        {
            DataHandler.Roomdata.Add(newRoom);
            return Created();
        }
        
        [HttpPut("{id:int}")]
        public IActionResult UpdateRoom(int id, [FromBody] Room updatedRoom)
        {
            Console.Out.WriteLine($"{updatedRoom.Id}, {updatedRoom.Name}");
            Room existingRoom = null;
            foreach (Room r in DataHandler.Roomdata)
                if (r.Id == id)
                    existingRoom = r;
            
            if (existingRoom == null) 
                return NotFound();

            existingRoom.Name = updatedRoom.Name;
            existingRoom.BuildingCode = updatedRoom.BuildingCode;
            existingRoom.Capacity = updatedRoom.Capacity;
            existingRoom.HasProjector = updatedRoom.HasProjector;
            existingRoom.IsActive = updatedRoom.IsActive;

            return Ok();
        }
        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteRoom(int id)
        {   
            Room tmp = null;
            foreach(Room r in DataHandler.Roomdata)
                if (r.Id == id)
                    tmp = r;
            
            if (tmp == null)
                return NotFound();
            
            DataHandler.Roomdata.Remove(tmp);
            return NoContent();
        }
    }
}
