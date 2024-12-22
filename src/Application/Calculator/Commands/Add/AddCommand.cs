using demo_app.Application.Common.Interfaces;
using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.Calculator.Commands.Add;

public record AddCommand : IRequest<decimal>, IUserId
{
    public decimal Value1 { get; init; }
    public decimal Value2 { get; init; }
    public Guid? UserId { get; private set; }
    void IUserId.SetUserId(Guid id)
    {
        UserId = id;
    }
}

public class AddCommandHandler(ICalculatorService calculatorService, IRepository<CalculationItem> repository) 
    : IRequestHandler<AddCommand, decimal>
{
    public async Task<decimal> Handle(AddCommand request, CancellationToken cancellationToken)
    {

        return await Task.Run(async () =>
        {
            var result = calculatorService.Add(request.Value1, request.Value2);

            if (request.UserId != null)
            {
                await repository.AddAsync(new CalculationItem
                {
                    UserId = request.UserId.Value,
                    Value1 = request.Value1,
                    Value2 = request.Value2,
                    Result = result,
                    Operation = CalculationOperation.Add
                });
            }
            return result;
        }, cancellationToken);
    }
}
