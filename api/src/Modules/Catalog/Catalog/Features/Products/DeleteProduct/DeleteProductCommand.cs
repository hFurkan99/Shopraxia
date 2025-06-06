namespace Catalog.Features.Products.DeleteProduct;

public record DeleteProductCommand(Guid ProductId)
    : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);