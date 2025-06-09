namespace Catalog.Domain.ProductAggregate.Dtos;

public record VariantDto(
    Guid Id,
    string Sku,
    decimal Price,
    int Stock,
    List<VariantAttributeDto> Attributes,
    List<ImageDto> Images);