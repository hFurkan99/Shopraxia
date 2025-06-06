namespace Catalog.Domain.AttributeAggregate;

public class Attribute : Aggregate<Guid>
{
    private readonly List<CategoryAttribute> _categoryAttributes = [];
    private readonly List<VariantAttribute> _variantAttributes = [];

    public string Name { get; set; } = default!;

    public IReadOnlyList<CategoryAttribute> CategoryAttributes => _categoryAttributes.AsReadOnly();
    public IReadOnlyList<VariantAttribute> VariantAttributes => _variantAttributes.AsReadOnly();


    private Attribute() { }

    public static Attribute Create(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var attribute = new Attribute
        {
            Id = Guid.NewGuid(),
            Name = name
        };

        return attribute;
    }

    public void Update(string name)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        Name = name;
    }
}