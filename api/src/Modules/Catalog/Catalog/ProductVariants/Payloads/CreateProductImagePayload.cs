namespace Catalog.ProductVariants.Payloads;

public record CreateProductImagePayload(
    string Url, 
    string AltText, 
    int SortOrder);