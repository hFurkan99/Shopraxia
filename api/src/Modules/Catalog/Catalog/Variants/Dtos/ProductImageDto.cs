namespace Catalog.Variants.Dtos;
public record ProductImageDto(
    Guid Id,
    string Url,
    string AltText,
    int SortOrder
);
