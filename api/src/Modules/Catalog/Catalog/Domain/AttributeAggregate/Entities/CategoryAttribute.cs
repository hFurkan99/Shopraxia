namespace Catalog.Domain.AttributeAggregate.Entities;

public class CategoryAttribute : Entity<Guid>
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public Guid AttributeId { get; set; }
    public Attribute Attribute { get; set; } = null!;

    private CategoryAttribute() { }

    public static CategoryAttribute Create(Guid categoryId, Guid attributeId)
    {
        GuidGuard.AgainstEmptyGuid(categoryId, nameof(categoryId));
        GuidGuard.AgainstEmptyGuid(attributeId, nameof(attributeId));

        return new CategoryAttribute
        {
            Id = Guid.NewGuid(),
            CategoryId = categoryId,
            AttributeId = attributeId
        };
    }
}
