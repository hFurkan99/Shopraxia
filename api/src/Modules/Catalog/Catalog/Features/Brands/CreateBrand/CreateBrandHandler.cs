namespace Catalog.Features.Brands.CreateBrand;

public record CreateBrandCommand(
    string Name,
    string Slug,
    string? Description)
    : ICommand<CreateBrandResult>;

public record CreateBrandResult(Guid Id);

public class CreateBrandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateBrandCommand, CreateBrandResult>
{
    public async Task<CreateBrandResult> Handle(
        CreateBrandCommand command, 
        CancellationToken cancellationToken)
    {
        var brand = CreateNewBrand(command.Name,
            command.Slug, command.Description);

        await unitOfWork.Brands.AddAsync(brand, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateBrandResult(brand.Id);
    }
    private static Brand CreateNewBrand(
        string name, 
        string slug, 
        string? description)
    {
        var brand = Brand.Create(name, slug, description);
        return brand;
    }
}