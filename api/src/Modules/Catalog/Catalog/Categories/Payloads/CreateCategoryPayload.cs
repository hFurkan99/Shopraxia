namespace Catalog.Categories.Payloads;

public record CreateCategoryPayload(
    string Name,
    string Slug,
    string Description);