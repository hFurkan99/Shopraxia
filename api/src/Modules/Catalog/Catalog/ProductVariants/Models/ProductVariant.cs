namespace Catalog.ProductVariants.Models;

public class ProductVariant : Entity<Guid>
{
    private readonly List<ProductAttribute> _attributes = [];
    private readonly List<ProductImage> _images = [];

    public string Sku { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public IReadOnlyList<ProductAttribute> Attributes => _attributes;
    public IReadOnlyList<ProductImage> Images => _images;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    private ProductVariant() { }

    public static ProductVariant Create(CreateProductVariantPayload variantPayload, Guid productId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(variantPayload.Sku);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(variantPayload.Price);
        ArgumentOutOfRangeException.ThrowIfNegative(variantPayload.Stock);

        if (variantPayload.Attributes == null || variantPayload.Attributes.Count == 0)
            throw new ArgumentException("Variant must have at least one attribute.");

        if (variantPayload.Images == null || variantPayload.Images.Count == 0)
            throw new ArgumentException("Variant must have at least one image.");

        var variant = new ProductVariant
        {
            Id = Guid.NewGuid(),
            Sku = variantPayload.Sku,
            Price = variantPayload.Price,
            Stock = variantPayload.Stock,
            ProductId = productId
        };

        foreach (var attrDto in variantPayload.Attributes)
        {
            variant._attributes.Add(ProductAttribute.Create(attrDto.Name, attrDto.Value));
        }

        foreach (var imgDto in variantPayload.Images)
        {
            variant._images.Add(ProductImage.Create(imgDto.Url, imgDto.AltText, imgDto.SortOrder));
        }

        return variant;
    }
}