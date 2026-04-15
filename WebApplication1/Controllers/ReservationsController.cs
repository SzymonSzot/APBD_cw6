using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private Reservation? FindById(int id)
        {
            foreach (var item in DataHandler.ReservationData)
                if (item.Id == id)
                    return item;
            return null;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Reservation>> GetReservations([FromQuery] DateOnly? date, [FromQuery] string? status, [FromQuery] int? roomId)
        {
            var query = DataHandler.ReservationData.AsQueryable();
            
            if (date.HasValue) 
                query = query.Where(r => (r.Date.Equals(date.Value)));
            
            if (!string.IsNullOrEmpty(status)) 
                query = query.Where(r => r.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
            
            if (roomId.HasValue) 
                query = query.Where(r => r.RoomId == roomId);

            return Ok(query.ToList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            var tmp = FindById(id);
            if (tmp == null)
                return NotFound();
            
            return Ok(tmp);
        }
        
        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateReservation(int id, [FromBody] Reservation updatedRes)
        {
            var existingRes = FindById(id);
            if (existingRes == null)
                return NotFound();
            
            existingRes.Date = updatedRes.Date;
            existingRes.Status = updatedRes.Status;
            existingRes.RoomId = updatedRes.RoomId;
            existingRes.EndTime = updatedRes.EndTime;
            existingRes.StartTime = updatedRes.StartTime;
            existingRes.OrganizerName = updatedRes.OrganizerName;
            existingRes.Topic =  updatedRes.Topic;
            
            return Ok();
        }
        
        [HttpPost]
        public IActionResult Create([FromBody] Reservation newRes)
        {
            Room room = null;
            foreach(Room r in DataHandler.Roomdata)
                if (r.Id == newRes.RoomId)
                    room = r;
            if (room == null) return NotFound();
            
            if (!room.IsActive) return BadRequest();
            
            bool hasConflict = DataHandler.ReservationData.Any(r => 
                r.RoomId == newRes.RoomId && 
                r.Date.Equals(newRes.Date) &&
                r.Status != "cancelled" &&
                newRes.StartTime.CompareTo(r.EndTime)<0 && newRes.EndTime.CompareTo(r.EndTime)>=0);

            if (hasConflict) return Conflict();
            
            DataHandler.ReservationData.Add(newRes);
            
            return Created();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var reservation = FindById(id);
            if (reservation == null) 
                return NotFound();

            DataHandler.ReservationData.Remove(reservation);
            return NoContent();
        }
    }
}
