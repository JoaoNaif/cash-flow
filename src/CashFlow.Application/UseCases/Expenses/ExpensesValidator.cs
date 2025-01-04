using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class ExpensesValidator : AbstractValidator<RequestExpensesJson>
{
    public ExpensesValidator()
    {
        RuleFor(expense => expense.Title).NotEmpty().WithMessage(ResourcesErrorMessages.TITLE_REQUIRED);
        RuleFor(expense => expense.Amount).GreaterThan(0).WithMessage(ResourcesErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(expense => expense.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourcesErrorMessages.EXMPENSES_CANNOT_FOR_THE_FUTURE);
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourcesErrorMessages.PAYMENT_TYPE_INVALID);
    }
}