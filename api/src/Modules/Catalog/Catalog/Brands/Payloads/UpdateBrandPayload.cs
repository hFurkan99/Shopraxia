namespace Catalog.Brands.Payloads;

public record UpdateBrandPayload(
    Guid Id,
    string Name,
    string Slug,
    string Description);