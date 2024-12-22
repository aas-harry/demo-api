namespace demo_app.Domain.Entities;
public class CalculationItem: BaseEntity
{
    public int UserId { get; set; }
    public decimal Value1 { get; set; }
    public decimal Value2 { get; set; }
    public decimal Result { get; set; }
    public CalculationOperation Operation { get; set; }

    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.Now;
}
