using Catalog.Variants.Models;

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

        builder.OwnsMany(pv => pv.Attributes, a =>
        {
            a.WithOwner().HasForeignKey("ProductVariantId");

            a.ToTable("ProductVariantAttributes");
            a.HasKey("ProductVariantId", "Name");

            a.Property<string>("Name")
            .HasColumnName("Name")
            .HasMaxLength(100)
            .ValueGeneratedNever();

            a.Property<string>("Value")
            .HasColumnName("Value")
            .HasMaxLength(100)
            .ValueGeneratedNever();
        });

        builder.OwnsMany(v => v.Images, i =>
        {
            i.WithOwner().HasForeignKey("ProductVariantId");

            i.ToTable("ProductVariantImages");
            i.HasKey("ProductVariantId", "SortOrder");

            i.Property<string>("Url")
            .HasColumnName("Url")
            .IsRequired()
            .ValueGeneratedNever();

            i.Property<string>("AltText")
            .HasColumnName("AltText")
            .ValueGeneratedNever();
        });
    }
}
