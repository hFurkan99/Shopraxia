namespace Catalog.Features.Brands.UpdateBrand;

public record UpdateBrandCommand(
    Guid Id,
    string Name,
    string Slug,
    string Description) 
    : ICommand<UpdateBrandResult>;

public record UpdateBrandResult(bool IsSuccess);