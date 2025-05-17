namespace Catalog.Products.Payloads;

public record UpdateProductPayload(
    Guid Id,
    string Name,
    string Slug,
    string Description,
    float Rating,
    Guid? CategoryId,
    Guid? BrandId);