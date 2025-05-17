namespace Catalog.Brands.Models;
public class Brand : Aggregate<Guid>
{
    private readonly List<Product> _products = [];

    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;

    public IReadOnlyList<Product> Products => _products.AsReadOnly();
}