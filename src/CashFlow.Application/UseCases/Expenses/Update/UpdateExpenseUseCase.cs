using AutoMapper;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Update;

public class UpdateExpenseUseCase : IUpdateExpenseUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpensesUpdateOnlyRepository _repository;

    public UpdateExpenseUseCase(IUnitOfWork unitOfWork, IMapper mapper, IExpensesUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public async Task Execute(long id, RequestExpensesJson request)
    {
        Validate(request);

        var expense = await _repository.GetById(id);

        if (expense is null)
        {
            throw new NotFoundException(ResourcesErrorMessages.EXPENSE_NOT_FOUND);
        }

        _mapper.Map(request, expense);
        
        _repository.Update(expense);
        
        await _unitOfWork.Commit();
    }

    private void Validate(RequestExpensesJson request)
    {
        var validator = new ExpensesValidator();
        
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}