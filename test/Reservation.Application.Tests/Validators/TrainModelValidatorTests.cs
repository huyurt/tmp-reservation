using FizzWare.NBuilder;
using FluentValidation.TestHelper;
using Reservation.Shared.Models;
using Reservation.Shared.Validators.Reservation;
using Xunit;

namespace Reservation.Application.Tests.Validators;

public class TrainModelValidatorTests
{
    private readonly TrainModelValidator _validator;
    
    public TrainModelValidatorTests()
    {
        _validator = new TrainModelValidator();
    }
    
    [Fact]
    public void Validator_Should_Have_Error_When_Wagon_Is_Empty()
    {
        var trainModel = new TrainModel();

        var result = _validator.TestValidate(trainModel);

        result.ShouldHaveValidationErrorFor(tm => tm.Wagons);
    }

    [Fact]
    public void Validator_Should_Not_Have_Error_When_All_Inputs_Are_Ok()
    {
        var trainModel = Builder<TrainModel>.CreateNew()
            .With(tm => tm.Wagons = Builder<WagonModel>.CreateListOfSize(1).Build())
            .Build();

        var result = _validator.TestValidate(trainModel);

        result.ShouldNotHaveValidationErrorFor(tm => tm.Wagons);
    }
}