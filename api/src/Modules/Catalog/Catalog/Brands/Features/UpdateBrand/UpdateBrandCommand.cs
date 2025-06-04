namespace Catalog.Brands.Features.UpdateBrand;

public record UpdateBrandCommand(UpdateBrandPayload BrandPayload) 
    : ICommand<UpdateBrandResult>;

public record UpdateBrandResult(bool IsSuccess);