namespace Catalog.Brands.Models;

public class Brand : Aggregate<Guid>
{
    private readonly List<Product> _products = [];

    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string Description { get; set; } = default!;

    public IReadOnlyList<Product> Products => _products.AsReadOnly();

    private Brand() { }

    public static Brand Create(CreateBrandPayload brandPayload)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brandPayload.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(brandPayload.Slug);

        var brand = new Brand
        {
            Id = Guid.NewGuid(),
            Name = brandPayload.Name,
            Slug = brandPayload.Slug,
            Description = brandPayload.Description
        };

        return brand;
    }

    public void Update(UpdateBrandPayload brandPayload)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(brandPayload.Name);
        ArgumentException.ThrowIfNullOrWhiteSpace(brandPayload.Slug);

        Name = brandPayload.Name;
        Slug = brandPayload.Slug;
        Description = brandPayload.Description;
    }
}