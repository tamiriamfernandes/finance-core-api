using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using financial.Model.Entities;

namespace financial.Infrastructure.Mapping;

public class StockMapping : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.ProductId)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(e => e.Amount)
            .IsRequired();

        builder.HasOne(e => e.Product)
            .WithOne(e => e.Stock)
            .HasForeignKey<Stock>(e => e.ProductId);
    }
}
