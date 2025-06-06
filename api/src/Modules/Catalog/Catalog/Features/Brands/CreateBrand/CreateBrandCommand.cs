namespace Catalog.Features.Brands.CreateBrand;

public record CreateBrandCommand(
    string Name,
    string Slug,
    string Description)
    : ICommand<CreateBrandResult>;

public record CreateBrandResult(Guid Id);
