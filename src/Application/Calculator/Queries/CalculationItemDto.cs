using demo_app.Domain.Entities;
using demo_app.Domain.Enums;

namespace demo_app.Application.Calculator.Queries;
public class CalculationItemDto
{
    public decimal Value1 { get; set; }
    public decimal Value2 { get; set; }
    public decimal Result { get; set; }
    public CalculationOperation Operation { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CalculationItem, CalculationItemDto>();
        }
    }
}
