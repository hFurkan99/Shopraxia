namespace Catalog.Features.Products.UpdateProduct;

public record UpdateProductCommand(
    Guid Id,
    string Name,
    string Slug,
    string Description,
    float Rating,
    Guid CategoryId,
    Guid BrandId)
    : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);

internal class UpdateProductHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(
        UpdateProductCommand command, 
        CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products.
            GetByIdAsync(command.Id, cancellationToken)
            ?? throw new ProductNotFoundException(command.Id);

        UpdateProduct(product, command.Name, command.Slug, command.Description,
            command.Rating, command.CategoryId, command.BrandId);

        unitOfWork.Products.Update(product);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }

    private static void UpdateProduct(
        Product product,
        string name,
        string slug,
        string description,
        float rating,
        Guid categoryId,
        Guid brandId)
    {
        product.Update(name, slug, description, 
            rating, categoryId, brandId);
    }
}