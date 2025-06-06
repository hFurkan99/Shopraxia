using Catalog.Domain.Common;
using Catalog.Domain.ProductAggregate;

namespace Catalog.Features.Products.CreateProduct;

internal class CreateProductHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var productPayload = command.ProductPayload;
        var product = CreateNewProduct(productPayload);
        await unitOfWork.Products.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }

    private static Product CreateNewProduct(CreateProductPayload productPayload)
    {
        var product = Product.Create(productPayload);
        return product;
    }
}
