namespace Catalog.Variants.Dtos;
public record ProductVariantDto(
    Guid Id,
    string Sku,
    decimal Price,
    int Stock,
    List<ProductAttributeDto> Attributes,
    List<ProductImageDto> Images
);