namespace Catalog.Products.Models;
public class Brand : Aggregate<Guid>
{
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;
}