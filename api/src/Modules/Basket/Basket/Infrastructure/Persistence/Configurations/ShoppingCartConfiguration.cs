using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basket.Infrastructure.Persistence.Configurations;
public class ShoppingCartConfiguration
    : IEntityTypeConfiguration<ShoppingCart>
{
    public void Configure(EntityTypeBuilder<ShoppingCart> builder)
    {
        builder.HasKey(sc => sc.Id);
        builder.Property(sc => sc.UserId)
            .IsRequired();
        builder.Property(sc => sc.CheckedOutAt)
            .IsRequired(false);
        
        builder.HasMany(sc => sc.Items)
            .WithOne()
            .HasForeignKey(i => i.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(sc => sc.UserId);
    }
}
