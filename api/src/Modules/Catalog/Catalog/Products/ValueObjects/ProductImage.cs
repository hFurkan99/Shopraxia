namespace Catalog.Products.ValueObjects;
public class ProductImage : Entity<Guid>
{
    public string Url { get; set; } = default!;
    public string AltText { get; set; } = default!;
    public int SortOrder { get; set; }
}