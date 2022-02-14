using Microsoft.AspNetCore.Mvc;

namespace Reservation.Api.Controllers
{
    public class HealthCheckController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Working!");
        }
    }
}
