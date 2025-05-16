namespace Catalog.Products.Models;

public class Product : Aggregate<Guid>
{
    private readonly List<ProductVariant> _variants = [];

    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;
    public float Rating { get; set; }

    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = default!;
    public Guid BrandId { get; set; }
    public string BrandName { get; set; } = default!;

    public IReadOnlyList<ProductVariant> Variants => _variants.AsReadOnly();

    private Product() { }

    public static Product Create(ProductDto productDto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productDto.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(productDto.Slug);
        ArgumentException.ThrowIfNullOrWhiteSpace(productDto.CategoryName);
        ArgumentException.ThrowIfNullOrWhiteSpace(productDto.BrandName);

        GuidGuard.AgainstEmptyGuid(productDto.CategoryId, nameof(productDto.CategoryId));
        GuidGuard.AgainstEmptyGuid(productDto.BrandId, nameof(productDto.BrandId));

        if (productDto.VariantDtos == null || productDto.VariantDtos.Count == 0)
            throw new ArgumentException("Product must have at least one variant.");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = productDto.Name,
            Slug = productDto.Slug,
            Description = productDto.Description,
            Rating = productDto.Rating,
            CategoryId = productDto.CategoryId,
            CategoryName = productDto.CategoryName,
            BrandId = productDto.BrandId,
            BrandName = productDto.BrandName
        };

        foreach (var variantDto in productDto.VariantDtos)
        {
            var variant = ProductVariant.Create(variantDto, product.Id);
            product._variants.Add(variant);
        }

        product.AddDomainEvent(new ProductCreatedEvent(product));
        return product;
    }
}