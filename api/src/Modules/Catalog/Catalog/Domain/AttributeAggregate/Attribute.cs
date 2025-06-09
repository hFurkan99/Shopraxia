namespace Catalog.Domain.AttributeAggregate;

public class Attribute : Aggregate<Guid>
{
    private readonly List<CategoryAttribute> _categoryAttributes = [];
    private readonly List<VariantAttribute> _variantAttributes = [];

    public string Name { get; set; } = default!;

    public IReadOnlyList<CategoryAttribute> CategoryAttributes => _categoryAttributes.AsReadOnly();
    public IReadOnlyList<VariantAttribute> VariantAttributes => _variantAttributes.AsReadOnly();


    private Attribute() { }

    public static Attribute Create(string name, Guid categoryId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        var attribute = new Attribute
        {
            Id = Guid.NewGuid(),
            Name = name,
            
        };

        CategoryAttribute.Create(categoryId, attribute.Id);
        return attribute;
    }

    public void Update(string name, Guid categoryId)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        GuidGuard.AgainstEmptyGuid(categoryId, nameof(categoryId));

        Name = name;

        var categoryAttribute = _categoryAttributes.
            FirstOrDefault(ca => ca.CategoryId == categoryId) ?? 
            throw new InvalidOperationException
                ($"CategoryAttribute for category {categoryId} not found.");

        categoryAttribute.Update(categoryId, Id);
    }
}