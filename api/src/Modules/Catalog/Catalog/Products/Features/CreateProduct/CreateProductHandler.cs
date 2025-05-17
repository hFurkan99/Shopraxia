namespace Catalog.Products.Features.CreateProduct;

internal class CreateProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var productPayload = command.ProductPayload;
        var product = CreateNewProduct(productPayload);
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }

    private static Product CreateNewProduct(CreateProductPayload productPayload)
    {
        var product = Product.Create(productPayload);
        return product;
    }
}
