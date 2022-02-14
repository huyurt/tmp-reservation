using System.Linq;
using FluentValidation;
using Reservation.Shared.Models;

namespace Reservation.Shared.Validators.Reservation
{
    public class CheckReservationInputModelValidator : AbstractValidator<CheckReservationInputModel>
    {
        public CheckReservationInputModelValidator()
        {
            RuleFor(cri => cri.CustomerCount)
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Rezervasyon yapılacak kişi sayısı hatalı.");
            
            RuleFor(cri => cri.Train)
                .NotNull()
                    .WithMessage("Tren bulunamadı.");

            RuleFor(cri => cri.Train)
                .SetValidator(cri => new TrainModelValidator());
        }
    }
}
