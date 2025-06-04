namespace Catalog.Categories.Models;

public class Category : Aggregate<Guid>
{
    private readonly List<Product> _products = [];

    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;

    public IReadOnlyList<Product> Products => _products.AsReadOnly();

    private Category() { }

    public static Category Create(CreateCategoryPayload categoryPayload)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(categoryPayload.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(categoryPayload.Slug);

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = categoryPayload.Name,
            Slug = categoryPayload.Slug,
            Description = categoryPayload.Description
        };

        return category;
    }

    public void Update(UpdateCategoryPayload categoryPayload)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(categoryPayload.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(categoryPayload.Slug);

        Name = categoryPayload.Name;
        Slug = categoryPayload.Slug;
        Description = categoryPayload.Description;
    }
}