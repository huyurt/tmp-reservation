using System.Linq;
using FizzWare.NBuilder;
using FluentValidation.TestHelper;
using Reservation.Shared.Models;
using Reservation.Shared.Validators.Reservation;
using Xunit;

namespace Reservation.Application.Tests.Validators;

public class WagonModelValidatorTests
{
    private readonly WagonModelValidator _validator;
    
    public WagonModelValidatorTests()
    {
        _validator = new WagonModelValidator();
    }
    
    [Fact]
    public void Validator_Should_Have_Error_When_SeatCapacity_Less_Than_Zero()
    {
        var wagonModel = new WagonModel { SeatCapacity = -1 };

        var result = _validator.TestValidate(wagonModel);

        result.ShouldHaveValidationErrorFor(wm => wm.SeatCapacity);
    }
    
    [Fact]
    public void Validator_Should_Have_Error_When_ReservedSeatCount_Less_Than_Zero()
    {
        var wagonModel = new WagonModel { ReservedSeatCount = -1 };

        var result = _validator.TestValidate(wagonModel);

        result.ShouldHaveValidationErrorFor(wm => wm.ReservedSeatCount);
    }
    
    [Fact]
    public void Validator_Should_Have_Error_When_SeatCapacity_Less_Than_ReservedSeatCount()
    {
        var wagonModel = new WagonModel
        {
            SeatCapacity = 3,
            ReservedSeatCount = 5,
        };

        var result = _validator.TestValidate(wagonModel);

        result.ShouldHaveValidationErrorFor(wm => wm.SeatCapacity);
    }

    [Fact]
    public void Validator_Should_Not_Have_Error_When_All_Inputs_Are_Ok()
    {
        var wagonModel = Builder<WagonModel>.CreateListOfSize(1).Build();

        var result = _validator.TestValidate(wagonModel.First());

        result.ShouldNotHaveValidationErrorFor(wm => wm);
    }
}