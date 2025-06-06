using Catalog.Domain.BrandAggregate;
using Catalog.Domain.Common;

namespace Catalog.Features.Brands.UpdateBrand;

internal class UpdateBrandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateBrandCommand, UpdateBrandResult>
{
    public async Task<UpdateBrandResult> Handle(
        UpdateBrandCommand command,
        CancellationToken cancellationToken)
    {
        var brand = await unitOfWork.Brands
            .GetByIdAsync(command.BrandPayload.Id, cancellationToken)
            ?? throw new BrandNotFoundException(command.BrandPayload.Id);

        UpdateBrand(brand, command.BrandPayload);

        unitOfWork.Brands.Update(brand);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateBrandResult(true);
    }

    private static void UpdateBrand(Brand brand, UpdateBrandPayload brandPayload)
    {
        brand.Update(brandPayload);
    }
}