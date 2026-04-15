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
