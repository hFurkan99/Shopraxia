namespace Catalog.Variants.Models;

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

    public static ProductVariant Create(ProductVariantDto variantDto, Guid productId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(variantDto.Sku);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(variantDto.Price);
        ArgumentOutOfRangeException.ThrowIfNegative(variantDto.Stock);

        if (variantDto.Attributes == null || variantDto.Attributes.Count == 0)
            throw new ArgumentException("Variant must have at least one attribute.");

        if (variantDto.Images == null || variantDto.Images.Count == 0)
            throw new ArgumentException("Variant must have at least one image.");

        var variant = new ProductVariant
        {
            Id = Guid.NewGuid(),
            Sku = variantDto.Sku,
            Price = variantDto.Price,
            Stock = variantDto.Stock,
            ProductId = productId
        };

        foreach (var attrDto in variantDto.Attributes)
        {
            variant._attributes.Add(ProductAttribute.Create(attrDto.Name, attrDto.Value));
        }

        foreach (var imgDto in variantDto.Images)
        {
            variant._images.Add(ProductImage.Create(imgDto.Url, imgDto.AltText, imgDto.SortOrder));
        }

        return variant;
    }
}