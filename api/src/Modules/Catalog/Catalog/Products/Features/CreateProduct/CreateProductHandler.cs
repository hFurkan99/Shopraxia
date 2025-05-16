namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCommand(ProductDto ProductDto) 
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductHandler(CatalogDbContext dbContext)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var productDto = command.ProductDto;
        var product = CreateNewProduct(productDto);
        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }

    private static Product CreateNewProduct(ProductDto productDto)
    {
        var product = Product.Create(productDto);
        return product;
    }
}
