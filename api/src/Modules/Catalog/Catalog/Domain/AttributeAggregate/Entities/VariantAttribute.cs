namespace Catalog.Domain.AttributeAggregate.Entities;

public class VariantAttribute : Entity<Guid>
{
    public Guid VariantId { get; set; }
    public Variant Variant { get; set; } = null!;

    public Guid AttributeId { get; set; }
    public Attribute Attribute { get; set; } = null!;

    public string Value { get; set; } = null!;

    public static VariantAttribute Create(
        Guid variantId, 
        Guid attributeId,
        string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        GuidGuard.AgainstEmptyGuid(variantId, nameof(variantId));
        GuidGuard.AgainstEmptyGuid(attributeId, nameof(attributeId));

        return new VariantAttribute
        {
            Id = Guid.NewGuid(),
            VariantId = variantId,
            AttributeId = attributeId,
            Value = value
        };
    }
}
