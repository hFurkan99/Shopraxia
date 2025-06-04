namespace Catalog.Brands.Features.CreateBrand;

public class CreateBrandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateBrandCommand, CreateBrandResult>
{
    public async Task<CreateBrandResult> Handle(
        CreateBrandCommand command, 
        CancellationToken cancellationToken)
    {
        var brandPayload = command.BrandPayload;
        var brand = CreateNewBrand(brandPayload);
        await unitOfWork.Brands.AddAsync(brand, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateBrandResult(brand.Id);
    }
    private static Brand CreateNewBrand(CreateBrandPayload brandPayload)
    {
        var brand = Brand.Create(brandPayload);
        return brand;
    }
}