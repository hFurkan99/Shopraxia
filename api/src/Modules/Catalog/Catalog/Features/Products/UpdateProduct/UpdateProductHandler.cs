using Catalog.Domain.Common;
using Catalog.Domain.ProductAggregate;

namespace Catalog.Features.Products.UpdateProduct;

internal class UpdateProductHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(
        UpdateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products.
            GetByIdAsync(command.ProductPayload.Id, cancellationToken)
            ?? throw new ProductNotFoundException(command.ProductPayload.Id);

        UpdateProduct(product, command.ProductPayload);

        unitOfWork.Products.Update(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }

    private static void UpdateProduct(Product product, UpdateProductPayload productPayload)
    {
        product.Update(productPayload);
    }
}