namespace CashFlow.Application.UseCases.Expenses.Register.Reports.Pdf;

public interface IGenerateExpensesReportPdfUseCase
{
    Task<byte[]> Execute(DateOnly month);
}