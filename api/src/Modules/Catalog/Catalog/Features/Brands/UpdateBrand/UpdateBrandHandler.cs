namespace Catalog.Features.Brands.UpdateBrand;

public record UpdateBrandCommand(
    Guid Id,
    string Name,
    string Slug,
    string? Description)
    : ICommand<UpdateBrandResult>;

public record UpdateBrandResult(bool IsSuccess);

internal class UpdateBrandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateBrandCommand, UpdateBrandResult>
{
    public async Task<UpdateBrandResult> Handle(
        UpdateBrandCommand command,
        CancellationToken cancellationToken)
    {
        var brand = await unitOfWork.Brands
            .GetByIdAsync(command.Id, cancellationToken)
            ?? throw new BrandNotFoundException(command.Id);

        UpdateBrand(brand, command.Name, 
            command.Slug, command.Description);

        unitOfWork.Brands.Update(brand);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateBrandResult(true);
    }

    private static void UpdateBrand(
        Brand brand,
        string name, 
        string slug, 
        string? description)
    {
        brand.Update(name, slug, description);
    }
}