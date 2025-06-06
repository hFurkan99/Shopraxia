namespace Catalog.Domain.ProductAggregate.Dtos;

public record ProductDto(
    Guid Id,
    string Name,
    string Slug,
    string Description,
    float Rating,
    CategoryDto Category,
    BrandDto Brand,
    List<VariantDto> Variants);