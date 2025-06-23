namespace Catalog.Contracts.Features.Products.GetProductById;
public record GetProductByIdQuery(Guid ProductId)
    : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(ProductDto Product);
