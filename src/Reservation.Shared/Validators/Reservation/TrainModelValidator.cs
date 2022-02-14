using FluentValidation;
using Reservation.Shared.Models;

namespace Reservation.Shared.Validators.Reservation
{
    public class TrainModelValidator : AbstractValidator<TrainModel>
    {
        public TrainModelValidator()
        {
            RuleFor(tm => tm)
                .NotNull()
                    .WithMessage("Tren bulunamadı.");

            RuleFor(tm => tm.Wagons)
                .NotNull()
                    .WithMessage("Vagon bulunamadı.");

            RuleFor(tm => tm.Wagons)
                .Must(wm => wm.Count > 0)
                    .WithMessage("Vagon bulunamadı.");
            
            RuleForEach(tm => tm.Wagons)
                .SetValidator(tm => new WagonModelValidator());
        }
    }
}