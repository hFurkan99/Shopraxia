namespace Catalog.Products.Features.UpdateProduct;

public record UpdateProductCommand(UpdateProductPayload ProductPayload)
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);