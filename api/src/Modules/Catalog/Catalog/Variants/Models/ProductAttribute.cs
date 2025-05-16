namespace Catalog.Variants.Models;

public class ProductAttribute : Entity<Guid>
{
    public string Name { get; set; } = default!;
    public string Value { get; set; } = default!;

    private ProductAttribute() { }

    public static ProductAttribute Create(string name, string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(value);

        var productAttribute = new ProductAttribute
        {
            Id = Guid.NewGuid(),
            Name = name,
            Value = value
        };

        return productAttribute;
    }
}
