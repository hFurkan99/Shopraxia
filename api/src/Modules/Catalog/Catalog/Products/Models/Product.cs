namespace Catalog.Products.Models;
public class Product : Aggregate<Guid>
{
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;
    public float Rating { get; set; }

    public Guid CategoryId { get; set; }
    public string CategoryName { get; set; } = default!;
    public Guid BrandId { get; set; }
    public string BrandName { get; set; } = default!;

    public List<ProductVariant> Variants { get; set; } = [];
}
