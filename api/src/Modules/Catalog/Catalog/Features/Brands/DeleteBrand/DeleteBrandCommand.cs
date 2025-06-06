namespace Catalog.Features.Brands.DeleteBrand;

public record DeleteBrandCommand(Guid BrandId) 
    : ICommand<DeleteBrandResult>;

public record DeleteBrandResult(bool IsSuccess);