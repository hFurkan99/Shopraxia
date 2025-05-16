namespace Catalog.Categories.Models;
public class Category : Aggregate<Guid>
{
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;
}