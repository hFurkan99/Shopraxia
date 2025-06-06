namespace Catalog.Features.Attributes.GetAttributes;

public record GetAttributesQuery() 
    : IQuery<GetAttributesResult>;

public record GetAttributesResult(List<AttributeDto> Attributes);

public record AttributeDto(Guid Id, string Name);