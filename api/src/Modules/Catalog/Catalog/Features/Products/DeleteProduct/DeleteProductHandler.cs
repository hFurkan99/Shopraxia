﻿namespace Catalog.Features.Products.DeleteProduct;

public record DeleteProductCommand(Guid ProductId)
    : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(
        DeleteProductCommand command, 
        CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products
            .GetByIdAsync(command.ProductId, cancellationToken)
            ?? throw new ProductNotFoundException(command.ProductId);

        unitOfWork.Products.Delete(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteProductResult(true);
    }
}