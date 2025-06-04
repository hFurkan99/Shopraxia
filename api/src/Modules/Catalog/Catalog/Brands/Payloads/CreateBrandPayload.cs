namespace Catalog.Brands.Payloads;

public record CreateBrandPayload(
    string Name,
    string Slug,
    string Description);
