using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using Xunit;

namespace Validators.Test.Expenses.Register;

public class ExpensesValidatorTest
{
    [Fact]
    public void Success()
    {
        var validator = new ExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        
        var result =  validator.Validate(request);
        
        result.IsValid.Should().BeTrue();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("     ")]
    public void ErrorTitleEmpty(string title)
    {
        var validator = new ExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Title = title;
        
        var result =  validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourcesErrorMessages.TITLE_REQUIRED));
    }
    
    [Fact]
    public void ErrorDateFuture()
    {
        var validator = new ExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Date = DateTime.UtcNow.AddDays(1);
        
        var result =  validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourcesErrorMessages.EXMPENSES_CANNOT_FOR_THE_FUTURE));
    }
    
    [Fact]
    public void ErrorPaymentTypeInvalid()
    {
        var validator = new ExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.PaymentType = (PaymentType)100;
        
        var result =  validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourcesErrorMessages.PAYMENT_TYPE_INVALID));
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-200)]
    public void ErrorAmountInvalid(decimal amount)
    {
        var validator = new ExpensesValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        request.Amount = amount;
        
        var result =  validator.Validate(request);
        
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourcesErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
    }
 }