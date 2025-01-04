using CashFlow.Domain.Entity;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);
    /// <summary>
    ///     This function returns TRUE if the deletion was successful otherwise returns FAlSE
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}