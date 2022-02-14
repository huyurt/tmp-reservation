using FluentValidation;
using Reservation.Shared.Models;

namespace Reservation.Shared.Validators.Reservation
{
    public class WagonModelValidator : AbstractValidator<WagonModel>
    {
        public WagonModelValidator()
        {
            RuleFor(w => w.SeatCapacity)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Koltuk kapasitesi hatalı.");

            RuleFor(w => w.ReservedSeatCount)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Dolu koltuk adeti hatalı.");

            RuleFor(w => w.SeatCapacity)
                .GreaterThanOrEqualTo(w => w.ReservedSeatCount)
                    .WithMessage("Dolu koltuk sayısı, koltuk kapasitesinden büyük olamaz.");
        }
    }
}