namespace Catalog.Products.Dtos;

public record ProductDto(
    Guid Id,
    string Name,
    string Slug,
    string Description,
    float Rating,
    Guid CategoryId,
    Guid BrandId,
    List<ProductVariantDto> Variants
);
