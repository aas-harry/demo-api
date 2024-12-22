using demo_app.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace demo_app.Infrastructure.Data.Configurations;
public class CalculationItemConfiguration : IEntityTypeConfiguration<CalculationItem>
{
    public void Configure(EntityTypeBuilder<CalculationItem> builder)
    {
        builder.Property(t => t.UserId)
            .IsRequired();
        builder.Property(t => t.Value1)
            .IsRequired();
        builder.Property(t => t.Value2)
            .IsRequired();
        builder.Property(t => t.Operation)
            .IsRequired();

        builder.Property(t => t.Result)
            .IsRequired();

    }
}
