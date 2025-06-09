namespace Catalog.Features.Categories.GetCategories;

public class GetCategoriesQueryValidator 
    : AbstractValidator<GetCategoriesQuery>
{
    public GetCategoriesQueryValidator()
    {
        RuleFor(query => query.Page)
            .GreaterThan(0)
            .WithMessage("Page number must be greater than 0.");

        RuleFor(query => query.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("Page size must be between 1 and 100.");

        RuleFor(query => query.Search)
            .MaximumLength(100)
            .WithMessage("Search term cannot exceed 100 characters.");
            
        RuleFor(query => query.SortBy)
            .Must(sortBy => string.IsNullOrEmpty(sortBy) 
                || sortBy == "name" || sortBy == "slug")
            .WithMessage("SortBy must be either 'name', 'slug', or null.");

        RuleFor(query => query.SortOrder)
            .Must(sortOrder => string.IsNullOrEmpty(sortOrder) 
                || sortOrder == "asc" || sortOrder == "desc")
            .WithMessage("SortOrder must be either 'asc', 'desc', or null.");
    }
}       