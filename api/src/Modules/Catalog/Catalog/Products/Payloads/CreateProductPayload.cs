namespace Catalog.Products.Payloads;

public record CreateProductPayload(
    string Name,
    string Slug,
    string Description,
    float Rating,
    Guid? CategoryId,
    Guid? BrandId,
    List<CreateProductVariantPayload> Variants);