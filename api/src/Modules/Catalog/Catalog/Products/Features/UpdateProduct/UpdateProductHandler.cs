namespace Catalog.Products.Features.UpdateProduct;

internal class UpdateProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var product = await dbContext.Products
            .Include(p => p.Variants)
            .FirstOrDefaultAsync(p => p.Id == command.ProductPayload.Id, cancellationToken) 
            ?? throw new ProductNotFoundException(command.ProductPayload.Id);

        UpdateProduct(product, command.ProductPayload);

        dbContext.Products.Update(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }

    private static void UpdateProduct(Product product, UpdateProductPayload productPayload)
    {
        product.Update(productPayload);
    }
}
