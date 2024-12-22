using demo_app.Application.Common.Interfaces;
using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.Calculator.Commands.Subtract;

public record SubtractCommand : IRequest<decimal>, IUserId
{
    public decimal Minuend { get; init; }
    public decimal Subtrahend { get; init; }
    public Guid? UserId { get; private set; }
    void IUserId.SetUserId(Guid id)
    {
        UserId = id;
    }
}

public class SubtractCommandCommandHandler(ICalculatorService calculatorService, IRepository<CalculationItem> repository) 
    : IRequestHandler<SubtractCommand, decimal>
{
    public async Task<decimal> Handle(SubtractCommand request, CancellationToken cancellationToken)
    {

        var result = await Task.Run(() => calculatorService.Subtract(request.Minuend, request.Subtrahend), cancellationToken);
        if (request.UserId != null)
        {
            await repository.AddAsync(new CalculationItem
            {
                UserId = request.UserId.Value,
                Value1 = request.Minuend,
                Value2 = request.Subtrahend,
                Result = result,
                Operation = CalculationOperation.Subtract
            });
        }
        return result;
    }
}
