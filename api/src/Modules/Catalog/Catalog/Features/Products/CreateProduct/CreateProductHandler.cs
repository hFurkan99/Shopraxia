namespace Catalog.Features.Products.CreateProduct;

public record CreateProductCommand(
    string Name,
    string Slug,
    string Description,
    float Rating,
    Guid CategoryId,
    Guid BrandId,
    List<CreateProductVariantPayload> Variants)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

internal class CreateProductHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(
        CreateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var product = CreateNewProduct(command.Name, command.Slug, 
            command.Description, command.Rating, command.CategoryId, 
            command.BrandId, command.Variants);

        await unitOfWork.Products.AddAsync(product, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }

    private static Product CreateNewProduct(
        string name,
        string slug,
        string description,
        float rating,
        Guid categoryId,
        Guid brandId,
        List<CreateProductVariantPayload> variantsPayload)
    {
        var variants = variantsPayload.Adapt<List<Variant>>();

        var product = Product.Create(name, slug, description,
            rating, categoryId, brandId, variants);
        return product;
    }
}
