namespace Catalog.Domain.CategoryAggregate;

public class Category : Aggregate<Guid>
{
    private readonly List<Product> _products = [];
    private readonly List<CategoryAttribute> _categoryAttributes = [];

    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string? Description { get; set; } = default!;

    public IReadOnlyList<Product> Products => _products.AsReadOnly();
    public IReadOnlyList<CategoryAttribute> CategoryAttributes => _categoryAttributes.AsReadOnly();

    private Category() { }

    public static Category Create(
        string name,
        string slug,
        string? description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(slug);

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            Slug = slug,
            Description = description
        };

        return category;
    }

    public void Update(
        string name,
        string slug,
        string? description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(slug);

        Name = name;
        Slug = slug;
        Description = description;
    }
}