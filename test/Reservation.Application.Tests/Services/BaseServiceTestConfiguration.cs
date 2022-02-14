using AutoMapper;
using Reservation.Shared.MappingProfiles;

namespace Reservation.Application.Tests.Services
{
    public class BaseServiceTestConfiguration
    {
        protected readonly IMapper _mapper;

        protected BaseServiceTestConfiguration()
        {
            _mapper = new MapperConfiguration(cfg => { cfg.AddMaps(typeof(MappingProfile)); }).CreateMapper();
        }
    }
}
