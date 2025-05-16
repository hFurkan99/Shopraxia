namespace Catalog.Variants.ValueObjects;

public class ProductImage : Entity<Guid>
{
    public string Url { get; set; } = default!;
    public string AltText { get; set; } = default!;
    public int SortOrder { get; set; }

    private ProductImage(string url, string altText, int sortOrder)
    {
        Url = url;
        AltText = altText;
        SortOrder = sortOrder;
    }

    public static ProductImage Create(string url, string altText, int sortOrder)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        ArgumentException.ThrowIfNullOrWhiteSpace(altText);

        if (sortOrder < 0)
            throw new ArgumentOutOfRangeException(nameof(sortOrder), "SortOrder must be non-negative.");

        var productImage = new ProductImage(url, altText, sortOrder)
        {
            Id = Guid.NewGuid(),
            Url = url,
            AltText = altText,
            SortOrder = sortOrder
        };

        return productImage;
    }
}