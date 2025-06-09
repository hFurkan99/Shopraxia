namespace Catalog.Domain.ProductAggregate.Dtos;

public record CreateProductVariantPayload(
    string Sku,
    decimal Price,
    int Stock,
    List<CreateVariantAttributePayload> VariantAttributes,
    List<CreateProductImagePayload> Images);

public record CreateProductImagePayload(
    string Url,
    string AltText,
    int SortOrder);

public record CreateVariantAttributePayload(string Value);
