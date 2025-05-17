namespace Catalog.ProductVariants.Payloads;

public record CreateProductVariantPayload(
    string Sku,
    decimal Price,
    int Stock,
    List<CreateProductAttributePayload> Attributes,
    List<CreateProductImagePayload> Images);