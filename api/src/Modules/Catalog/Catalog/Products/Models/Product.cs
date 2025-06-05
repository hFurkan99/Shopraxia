namespace Catalog.Products.Models;

public class Product : Aggregate<Guid>
{
    private readonly List<ProductVariant> _variants = [];

    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;
    public float Rating { get; set; }

    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public Guid? BrandId { get; set; }
    public Brand? Brand { get; set; }

    public IReadOnlyList<ProductVariant> Variants => _variants.AsReadOnly();

    private Product() { }

    public static Product Create(CreateProductPayload productPayload)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productPayload.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(productPayload.Slug);

        GuidGuard.AgainstEmptyGuid(productPayload.CategoryId, nameof(productPayload.CategoryId));
        GuidGuard.AgainstEmptyGuid(productPayload.BrandId, nameof(productPayload.BrandId));

        if (productPayload.Variants == null || productPayload.Variants.Count == 0)
            throw new ArgumentException("Product must have at least one variant.");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = productPayload.Name,
            Slug = productPayload.Slug,
            Description = productPayload.Description,
            Rating = productPayload.Rating,
            CategoryId = productPayload.CategoryId,
            BrandId = productPayload.BrandId
        };

        foreach (var variantPayload in productPayload.Variants)
        {
            var variant = ProductVariant.Create(variantPayload, product.Id);
            product._variants.Add(variant);
        }

        product.AddDomainEvent(new ProductCreatedEvent(product));
        return product;
    }

    public void Update(UpdateProductPayload productPayload)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(productPayload.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(productPayload.Slug);

        GuidGuard.AgainstEmptyGuid(productPayload.CategoryId, nameof(productPayload.CategoryId));
        GuidGuard.AgainstEmptyGuid(productPayload.BrandId, nameof(productPayload.BrandId));

        Name = productPayload.Name;
        Slug = productPayload.Slug;
        Description = productPayload.Description;
        Rating = productPayload.Rating;
        CategoryId = productPayload.CategoryId;
        BrandId = productPayload.BrandId;
    }
}