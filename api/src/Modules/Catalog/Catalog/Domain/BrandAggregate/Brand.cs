namespace Catalog.Domain.BrandAggregate;

public class Brand : Aggregate<Guid>
{
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string? Description { get; set; }

    private Brand() { }

    public static Brand Create(string name, string slug, string? description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(slug);

        var brand = new Brand
        {
            Id = Guid.NewGuid(),
            Name = name,
            Slug = slug,
            Description = description
        };

        return brand;
    }

    public void Update(string name, string slug, string? description)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(slug);

        Name = name;
        Slug = slug;
        Description = description;
    }
}