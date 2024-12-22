using demo_app.Application.Common.Interfaces;
using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.Calculator.Commands.Multiply;

public record MultiplyCommand : IRequest<decimal>, IUserId
{
    public decimal Value1 { get; init; }
    public decimal Value2 { get; init; }
    public Guid? UserId { get; private set; }
    void IUserId.SetUserId(Guid id)
    {
        UserId = id;
    }
}

public class MultiplyCommandHandler(ICalculatorService calculatorService, IRepository<CalculationItem> repository) 
    : IRequestHandler<MultiplyCommand, decimal>
{
    public async Task<decimal> Handle(MultiplyCommand request, CancellationToken cancellationToken)
    {

        var result = await Task.Run(() => calculatorService.Multiply(request.Value1, request.Value2), cancellationToken);

        if (request.UserId != null)
        {
            await repository.AddAsync(new CalculationItem
            {
                UserId = request.UserId.Value,
                Value1 = request.Value1,
                Value2 = request.Value2,
                Result = result,
                Operation = CalculationOperation.Multiply
            });
        }
        return result;
    }
}
