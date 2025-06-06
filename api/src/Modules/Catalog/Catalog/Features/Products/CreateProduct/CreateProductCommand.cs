namespace Catalog.Features.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Slug,
    string Description,
    float Rating,
    Guid CategoryId,
    Guid BrandId,
    List<CreateProductVariantPayload> Variants)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public record CreateProductVariantPayload(
    string Sku,
    decimal Price,
    int Stock,
    List<CreateVariantAttributePayload> Attributes,
    List<CreateProductImagePayload> Images);

public record CreateProductImagePayload(
    string Url,
    string AltText,
    int SortOrder);

public record CreateVariantAttributePayload(string Value);
