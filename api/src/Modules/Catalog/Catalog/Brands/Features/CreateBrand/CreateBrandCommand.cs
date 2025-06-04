namespace Catalog.Brands.Features.CreateBrand;

public record CreateBrandCommand(CreateBrandPayload BrandPayload)
    : ICommand<CreateBrandResult>;

public record CreateBrandResult(Guid Id);
