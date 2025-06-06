namespace Catalog.Features.Attributes.GetAttributeById;

public record GetAttributeByIdQuery(Guid AttributeId) 
    : IQuery<GetAttributeByIdResult>;

public record GetAttributeByIdResult(
    Guid Id,
    string Name);