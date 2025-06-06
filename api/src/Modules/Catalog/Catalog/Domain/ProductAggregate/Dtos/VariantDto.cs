namespace Catalog.Domain.ProductAggregate.Dtos;

public record VariantDto(
    Guid Id,
    string Sku,
    decimal Price,
    int Stock,
    List<AttributeDto> Attributes,
    List<ImageDto> Images);