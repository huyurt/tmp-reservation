using Microsoft.AspNetCore.Mvc;
using Reservation.Application.Services.Abstract;
using Reservation.Shared.Models;

namespace Reservation.Api.Controllers
{
    public class ReservationController : ApiController
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost]
        public async Task<IActionResult> CheckReservationAsync([FromBody] CheckReservationInputModel checkReservationInputModel)
        {
            return Ok(await _reservationService.CheckReservationAsync(checkReservationInputModel));
        }
    }
}
