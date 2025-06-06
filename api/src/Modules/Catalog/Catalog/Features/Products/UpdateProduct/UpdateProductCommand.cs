namespace Catalog.Features.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Slug,
    string Description,
    float Rating,
    Guid CategoryId,
    Guid BrandId)
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);