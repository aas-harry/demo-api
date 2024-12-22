using demo_app.Application.Common.Interfaces;
using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.Calculator.Commands.Divide;

public record DivideCommand : IRequest<decimal>, IUserId
{
    public decimal Dividend { get; init; }
    public decimal Divisor { get; init; }
    public Guid? UserId { get; private set; }
    void IUserId.SetUserId(Guid id)
    {
        UserId = id;
    }
}

public class DivideCommandHandler(ICalculatorService calculatorService, IRepository<CalculationItem> repository) 
    : IRequestHandler<DivideCommand, decimal>
{
    public async Task<decimal> Handle(DivideCommand request, CancellationToken cancellationToken)
    {

        var result = await Task.Run(() => calculatorService.Divide(request.Dividend, request.Divisor), cancellationToken);
        if (request.UserId != null)
        {
            await repository.AddAsync(new CalculationItem
            {
                UserId = request.UserId.Value,
                Value1 = request.Dividend,
                Value2 = request.Divisor,
                Result = result,
                Operation = CalculationOperation.Divide
            });
        }
        return result;
    }
}
