using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.Infrastructure.Persistence.Configurations;

public class ShoppingCartItemConfiguration
    : IEntityTypeConfiguration<ShoppingCartItem>
{
    public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.ShoppingCartId)
            .IsRequired();
        builder.Property(i => i.ProductId)
            .IsRequired();
        builder.Property(i => i.VariantId)
            .IsRequired(false);
        builder.Property(i => i.Quantity)
            .IsRequired()
            .HasDefaultValue(1);
        builder.Property(i => i.UnitPrice)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        builder.HasIndex(i => new { i.ShoppingCartId, i.ProductId, i.VariantId })
            .IsUnique();
    }
}
