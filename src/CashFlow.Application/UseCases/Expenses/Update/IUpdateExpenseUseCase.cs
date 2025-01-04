using CashFlow.Communication.Requests;
using CashFlow.Domain.Entity;

namespace CashFlow.Application.UseCases.Expenses.Update;

public interface IUpdateExpenseUseCase
{
    Task Execute(long id, RequestExpensesJson request);
}