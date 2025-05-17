namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCommand(CreateProductPayload ProductPayload)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);
