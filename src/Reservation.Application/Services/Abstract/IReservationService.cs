using System.Threading.Tasks;
using Reservation.Shared.Models;

namespace Reservation.Application.Services.Abstract
{
    public interface IReservationService
    {
        Task<CheckReservationOutputModel> CheckReservationAsync(CheckReservationInputModel input);
    }
}
