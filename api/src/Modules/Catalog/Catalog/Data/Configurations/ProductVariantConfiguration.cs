namespace Catalog.Data.Configurations;

public class ProductVariantConfiguration
{
    public static void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.HasKey(pv => pv.Id);

        builder.Property(pv => pv.Sku)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(pv => pv.Price)
            .IsRequired();

        builder.Property(pv => pv.Stock)
            .IsRequired();

        builder.HasMany(pv => pv.Attributes)
            .WithOne(pa => pa.ProductVariant)
            .HasForeignKey(pa => pa.ProductVariantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(pv => pv.Images)
            .WithOne()
            .HasForeignKey(pa => pa.ProductVariantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
