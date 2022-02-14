using FizzWare.NBuilder;
using FluentValidation.TestHelper;
using Reservation.Shared.Models;
using Reservation.Shared.Validators.Reservation;
using Xunit;

namespace Reservation.Application.Tests.Validators;

public class CheckReservationInputModelValidatorTests
{
    private readonly CheckReservationInputModelValidator _validator;
    
    public CheckReservationInputModelValidatorTests()
    {
        _validator = new CheckReservationInputModelValidator();
    }
    
    [Fact]
    public void Validator_Should_Have_Error_When_CustomerCount_Less_Than_Zero()
    {
        var checkReservationInputModel = new CheckReservationInputModel
        {
            CustomerCount = -1,
            Train = Builder<TrainModel>.CreateNew()
                .With(tm => tm.Wagons = Builder<WagonModel>.CreateListOfSize(1).Build())
                .Build()
        };

        var result = _validator.TestValidate(checkReservationInputModel);

        result.ShouldHaveValidationErrorFor(cri => cri.CustomerCount);
    }
    
    [Fact]
    public void Validator_Should_Have_Error_When_Train_Is_Null()
    {
        var checkReservationInputModel = new CheckReservationInputModel { Train = null };

        var result = _validator.TestValidate(checkReservationInputModel);

        result.ShouldHaveValidationErrorFor(cri => cri.Train);
    }
    
    [Fact]
    public void Validator_Should_Have_Error_When_Wagon_Is_Empty()
    {
        var checkReservationInputModel = Builder<CheckReservationInputModel>.CreateNew()
            .With(cri => cri.Train = Builder<TrainModel>.CreateNew().Build())
            .Build();

        var result = _validator.TestValidate(checkReservationInputModel);

        result.ShouldHaveValidationErrorFor(cri => cri.Train.Wagons);
    }

    [Fact]
    public void Validator_Should_Not_Have_Error_When_All_Inputs_Are_Ok()
    {
        var checkReservationInputModel = Builder<CheckReservationInputModel>.CreateNew()
            .With(cri => cri.Train = Builder<TrainModel>.CreateNew()
                .With(tm => tm.Wagons = Builder<WagonModel>.CreateListOfSize(1).Build())
                .Build())
            .Build();

        var result = _validator.TestValidate(checkReservationInputModel);

        result.ShouldNotHaveValidationErrorFor(cri => cri.Train);
        result.ShouldNotHaveValidationErrorFor(cri => cri.Train.Wagons);
        result.ShouldNotHaveValidationErrorFor(cri => cri.CustomerCount);
    }
}