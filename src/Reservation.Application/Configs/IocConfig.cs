using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Services.Abstract;
using Reservation.Application.Services.Concrete;

namespace Reservation.Application.Configs
{
    public static class IocConfig
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IReservationService, ReservationService>();
        }
    }
}
