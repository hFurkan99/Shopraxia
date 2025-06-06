namespace Catalog.Domain.ProductAggregate;

public class Product : Aggregate<Guid>
{
    private readonly List<Variant> _variants = [];

    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;
    public float Rating { get; set; } = default!;

    public Guid CategoryId { get; set; } = default!;
    public Category Category { get; set; } = default!;
    public Guid BrandId { get; set; } = default!;
    public Brand Brand { get; set; } = default!;

    public IReadOnlyList<Variant> Variants => _variants.AsReadOnly();

    private Product() { }

    public static Product Create(
        string name,
        string slug,
        string description,
        float rating,
        Guid categoryId,
        Guid brandId,
        List<Variant> variants)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(slug);

        GuidGuard.AgainstEmptyGuid(categoryId, nameof(categoryId));
        GuidGuard.AgainstEmptyGuid(brandId, nameof(brandId));

        if (variants == null || variants.Count == 0)
            throw new ArgumentException("Product must have at least one variant.");

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Slug = slug,
            Description = description,
            Rating = rating,
            CategoryId = categoryId,
            BrandId = brandId
        };

        foreach (var variant in variants)
        {
            var newVariant = Variant.Create(
                variant.Sku,
                variant.Price,
                variant.Stock,
                [.. variant.VariantAttributes],
                [.. variant.Images],
                product.Id);
            product._variants.Add(newVariant);
        }

        product.AddDomainEvent(new ProductCreatedEvent(product));
        return product;
    }

    public void Update(
        string name,
        string slug,
        string description,
        float rating,
        Guid categoryId,
        Guid brandId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(slug);

        GuidGuard.AgainstEmptyGuid(categoryId, nameof(categoryId));
        GuidGuard.AgainstEmptyGuid(brandId, nameof(brandId));

        Name = name;
        Slug = slug;
        Description = description;
        Rating = rating;
        CategoryId = categoryId;
        BrandId = brandId;
    }
}