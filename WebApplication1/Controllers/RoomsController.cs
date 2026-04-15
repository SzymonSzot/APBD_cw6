using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private Room? FindById(int id)
        {
            foreach (Room r in DataHandler.Roomdata)
                if (r.Id == id)
                    return r;
            return null;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Room>> GetRooms(
            [FromQuery] int? minCapacity, 
            [FromQuery] bool? hasProjector, 
            [FromQuery] bool? activeOnly)
        {
            var query = DataHandler.Roomdata.AsQueryable();
            
            if (minCapacity.HasValue)
                query = query.Where(r => r.Capacity >= minCapacity.Value);

            if (hasProjector.HasValue)
                query = query.Where(r => r.HasProjector == hasProjector.Value);

            if (activeOnly.HasValue && activeOnly.Value)
                query = query.Where(r => r.IsActive);

            return Ok(query.ToList());
        }
        
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var tmp = FindById(id);

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
            var existingRoom = FindById(updatedRoom.Id);
            
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
            var tmp = FindById(id);
            
            if (tmp == null)
                return NotFound();
            
            foreach (var reservation in DataHandler.ReservationData)
            {
                if (reservation.RoomId == id)
                {
                    return Conflict();
                }
            }
            
            DataHandler.Roomdata.Remove(tmp);
            return NoContent();
        }
    }
}
