namespace Catalog.Domain.ProductAggregate.Entities;

public class Image : Entity<Guid>
{
    public string Url { get; set; } = default!;
    public string AltText { get; set; } = default!;
    public int SortOrder { get; set; }

    public Guid VariantId { get; set; }

    private Image() { }

    public static Image Create(string url, string altText, int sortOrder)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(url);
        ArgumentException.ThrowIfNullOrWhiteSpace(altText);

        if (sortOrder < 0)
            throw new ArgumentOutOfRangeException(nameof(sortOrder), "SortOrder must be non-negative.");

        var productImage = new Image
        {
            Id = Guid.NewGuid(),
            Url = url,
            AltText = altText,
            SortOrder = sortOrder
        };

        return productImage;
    }
}