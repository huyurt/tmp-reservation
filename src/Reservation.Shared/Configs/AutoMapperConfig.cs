using Microsoft.Extensions.DependencyInjection;
using Reservation.Shared.MappingProfiles;

namespace Reservation.Shared.Configs
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }
    }
}
