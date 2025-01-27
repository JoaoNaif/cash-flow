using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionBase;
using PaymentType = CashFlow.Domain.Entity.PaymentType;

namespace CashFlow.Application.UseCases.Expenses.Register;

public class RegisterExpensesUseCase : IRegisterExpensesUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public RegisterExpensesUseCase(
        IExpensesWriteOnlyRepository repository, 
        IUnitOfWork unitOfWork, 
        IMapper mapper
        )
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async Task<ResponseRegisterExpensesJson> Execute(RequestExpensesJson request)
    {
        Validate(request);

        var entity = _mapper.Map<Expense>(request);
        
        await _repository.Add(entity);
        
        await _unitOfWork.Commit();
        
        return _mapper.Map<ResponseRegisterExpensesJson>(entity);
    }

    private void Validate(RequestExpensesJson request)
    {
        var validator = new ExpensesValidator();
        
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMensages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMensages);
        }
    }
}