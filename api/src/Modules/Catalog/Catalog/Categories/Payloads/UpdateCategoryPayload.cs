namespace Catalog.Categories.Payloads;

public record UpdateCategoryPayload(
    Guid Id,
    string Name,
    string Slug,
    string Description);