namespace Catalog.Domain.ProductAggregate.Entities;

public class Variant : Entity<Guid>
{
    private readonly List<Image> _images = [];
    private readonly List<VariantAttribute> _variantAttributes = [];

    public string Sku { get; set; } = default!;
    public decimal Price { get; set; }
    public long Stock { get; set; }

    public IReadOnlyList<Image> Images => _images;
    public IReadOnlyList<VariantAttribute> VariantAttributes => _variantAttributes;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    private Variant() { }

    public static Variant Create(
        string sku,
        decimal price,
        long stock,
        List<VariantAttribute> variantAttributes,
        List<Image> images,
        Guid productId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(sku);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(price);
        ArgumentOutOfRangeException.ThrowIfNegative(stock);

        if (variantAttributes == null || variantAttributes.Count == 0)
            throw new ArgumentException("Variant must have at least one attribute.");

        if (images == null || images.Count == 0)
            throw new ArgumentException("Variant must have at least one image.");

        var variant = new Variant
        {
            Id = Guid.NewGuid(),
            Sku = sku,
            Price = price,
            Stock = stock,
            ProductId = productId
        };

        foreach (var variantAttribute in variantAttributes)
        {
            variant._variantAttributes.Add(VariantAttribute.Create(
                variant.Id, 
                variantAttribute.AttributeId, 
                variantAttribute.Value));
        }

        foreach (var image in images)
        {
            variant._images.
                Add(Image.Create(image.Url, image.AltText, image.SortOrder));
        }

        return variant;
    }
}