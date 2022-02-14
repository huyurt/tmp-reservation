using System.Collections.Generic;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using Reservation.Application.Services.Abstract;
using Reservation.Application.Services.Concrete;
using Reservation.Shared.Models;
using Xunit;

namespace Reservation.Application.Tests.Services
{
    public class ReservationServiceTests : BaseServiceTestConfiguration
    {
        private readonly IReservationService _reservationService;

        public ReservationServiceTests()
        {
            _reservationService = new ReservationService(_mapper);
        }

        [Fact]
        public async Task CheckReservationAsync_Should_Return_One_Wagon()
        {
            var checkReservationInputModel = new CheckReservationInputModel
            {
                Train = Builder<TrainModel>.CreateNew()
                    .With(tm => tm.Wagons = new List<WagonModel>
                    {
                        new() { Title = "Vagon 1", SeatCapacity = 100, ReservedSeatCount = 50 },
                        new() { Title = "Vagon 2", SeatCapacity = 90, ReservedSeatCount = 80 },
                        new() { Title = "Vagon 3", SeatCapacity = 80, ReservedSeatCount = 80 },
                    }
                ).Build(),
                CustomerCount = 3,
                DifferentWagonControl = true,
            };
            
            var result = await _reservationService.CheckReservationAsync(checkReservationInputModel);

            result.Should().NotBeNull();
            result.IsReservationPossible.Should().BeTrue();
            result.CheckReservations.Should().HaveCount(1);
        }

        [Fact]
        public async Task CheckReservationAsync_Should_Return_Two_Wagons()
        {
            var checkReservationInputModel = new CheckReservationInputModel
            {
                Train = Builder<TrainModel>.CreateNew()
                    .With(tm => tm.Wagons = new List<WagonModel>
                    {
                        new() { Title = "Vagon 1", SeatCapacity = 100, ReservedSeatCount = 63 },
                        new() { Title = "Vagon 2", SeatCapacity = 90, ReservedSeatCount = 80 },
                        new() { Title = "Vagon 3", SeatCapacity = 80, ReservedSeatCount = 50 },
                    }
                ).Build(),
                CustomerCount = 10,
                DifferentWagonControl = true,
            };
            
            var result = await _reservationService.CheckReservationAsync(checkReservationInputModel);

            result.Should().NotBeNull();
            result.IsReservationPossible.Should().BeTrue();
            result.CheckReservations.Should().HaveCount(2);
        }

        [Fact]
        public async Task CheckReservationAsync_Should_Return_Single_Wagon()
        {
            var checkReservationInputModel = new CheckReservationInputModel
            {
                Train = Builder<TrainModel>.CreateNew()
                    .With(tm => tm.Wagons = new List<WagonModel>
                    {
                        new() { Title = "Vagon 1", SeatCapacity = 100, ReservedSeatCount = 60 },
                        new() { Title = "Vagon 2", SeatCapacity = 90, ReservedSeatCount = 50 },
                        new() { Title = "Vagon 3", SeatCapacity = 80, ReservedSeatCount = 41 },
                    }
                ).Build(),
                CustomerCount = 15,
                DifferentWagonControl = false,
            };
            
            var result = await _reservationService.CheckReservationAsync(checkReservationInputModel);

            result.Should().NotBeNull();
            result.IsReservationPossible.Should().BeTrue();
            result.CheckReservations.Should().HaveCount(1);
        }

        [Fact]
        public async Task CheckReservationAsync_Should_Not_Return_Any_Wagon()
        {
            var checkReservationInputModel = new CheckReservationInputModel
            {
                Train = Builder<TrainModel>.CreateNew()
                    .With(tm => tm.Wagons = new List<WagonModel>
                    {
                        new() { Title = "Vagon 1", SeatCapacity = 100, ReservedSeatCount = 60 },
                        new() { Title = "Vagon 2", SeatCapacity = 90, ReservedSeatCount = 50 },
                        new() { Title = "Vagon 3", SeatCapacity = 80, ReservedSeatCount = 41 },
                    }
                ).Build(),
                CustomerCount = 40,
                DifferentWagonControl = true,
            };

            var result = await _reservationService.CheckReservationAsync(checkReservationInputModel);

            result.Should().NotBeNull();
            result.IsReservationPossible.Should().BeFalse();
            result.CheckReservations.Should().HaveCount(0);
        }

        [Fact]
        public async Task CheckReservationAsync_Empty_Wagon_Should_Not_Return_Any_Wagon()
        {
            var checkReservationInputModel = new CheckReservationInputModel
            {
                Train = Builder<TrainModel>.CreateNew().Build(),
                CustomerCount = 1,
                DifferentWagonControl = true
            };
            
            var result = await _reservationService.CheckReservationAsync(checkReservationInputModel);

            result.Should().NotBeNull();
            result.IsReservationPossible.Should().BeFalse();
            result.CheckReservations.Should().HaveCount(0);
        }
    }
}
