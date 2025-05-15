namespace Catalog.Data.Configurations;
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        builder.Property(p => p.Rating);

        builder.Property(p => p.CategoryId)
            .IsRequired();

        builder.Property(p => p.CategoryName)
            .IsRequired();

        builder.Property(p => p.BrandId)
            .IsRequired();

        builder.Property(p => p.BrandName)
            .IsRequired();

        builder.HasMany(p => p.Variants)
            .WithOne(pv => pv.Product)
            .HasForeignKey(pv => pv.ProductId);    
    }
}
