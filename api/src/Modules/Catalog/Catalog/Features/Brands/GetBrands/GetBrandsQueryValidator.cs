namespace Catalog.Features.Brands.GetBrands;

public class GetBrandsQueryValidator 
    : AbstractValidator<GetBrandsQuery>
{
    public GetBrandsQueryValidator()
    {
        RuleFor(query => query.BrandsPayload.Page)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0.");

        RuleFor(query => query.BrandsPayload.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("Page size must be between 1 and 100.");

        RuleFor(query => query.BrandsPayload.Search)
            .MaximumLength(100)
            .WithMessage("Search term cannot exceed 100 characters.");

        RuleFor(query => query.BrandsPayload.SortBy)
            .Must(sortBy => string.IsNullOrEmpty(sortBy) 
            || sortBy == "name" || sortBy == "slug")
            .WithMessage("SortBy must be either 'name', 'slug', or null.");

        RuleFor(query => query.BrandsPayload.SortOrder)
            .Must(sortOrder => string.IsNullOrEmpty(sortOrder) 
            || sortOrder == "asc" || sortOrder == "desc")
            .WithMessage("SortOrder must be either 'asc', 'desc', or null.");
    }
}   