using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Reservation.Application.Services.Abstract;
using Reservation.Shared.Consts;
using Reservation.Shared.Models;

namespace Reservation.Application.Services.Concrete
{
    public class ReservationService : IReservationService
    {
        private readonly IMapper _mapper;

        public ReservationService(
            IMapper mapper
        )
        {
            _mapper = mapper;
        }

        public async Task<CheckReservationOutputModel> CheckReservationAsync(CheckReservationInputModel input)
        {
            var suitableWagons = GetSuitableWagons(input);

            var sittingPlans = GetSittingPlan(input.CustomerCount, suitableWagons);

            return sittingPlans;
        }

        private List<SuitableWagonDtoModel> GetSuitableWagons(CheckReservationInputModel input)
        {
            var suitableWagons = CalculateEmptySeats(input.Train.Wagons);
            
            if (input.DifferentWagonControl)
            {
                return suitableWagons;
            }

            suitableWagons = suitableWagons.Where(w => w.EmptySeatCount >= input.CustomerCount).ToList();
            if (suitableWagons.Any())
            {
                suitableWagons = new List<SuitableWagonDtoModel> { suitableWagons.First() };
            }

            return suitableWagons;
        }

        private List<SuitableWagonDtoModel> CalculateEmptySeats(ICollection<WagonModel> wagons)
        {
            return wagons.Select(w => new SuitableWagonDtoModel
                {
                    Title = w.Title,
                    EmptySeatCount = (int)Math.Floor(w.SeatCapacity * ReservationConsts.CapacityRatio) - w.ReservedSeatCount
                })
                .Where(w => w.EmptySeatCount > 0).ToList();
        }

        private CheckReservationOutputModel GetSittingPlan(int customerCount, List<SuitableWagonDtoModel> suitableWagons)
        {
            var output = new CheckReservationOutputModel();

            if (suitableWagons.Sum(w => w.EmptySeatCount) < customerCount)
                return output;

            foreach (var suitableWagon in suitableWagons)
            {
                var emptySeatCount = suitableWagon.EmptySeatCount >= customerCount ? customerCount : suitableWagon.EmptySeatCount;
                customerCount -= emptySeatCount;

                output.CheckReservations.Add(new CheckReservationDtoModel
                {
                    WagonTitle = suitableWagon.Title,
                    CustomerCount = emptySeatCount,
                });

                if (customerCount <= 0)
                    return output;
            }

            return output;
        }
    }
}
