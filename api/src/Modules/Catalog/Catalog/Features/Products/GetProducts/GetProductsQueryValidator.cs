namespace Catalog.Features.Products.GetProducts;

public class GetProductsQueryValidator 
    : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0);

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100);

        RuleFor(x => x.SortBy)
            .Must(sortBy => string.IsNullOrEmpty(sortBy) 
            || sortBy == "name" 
            || sortBy == "price" 
            || sortBy == "rating")
            .WithMessage("SortBy must be either 'name', 'price', or null.");    

        RuleFor(x => x.SortOrder)
            .Must(sortOrder => string.IsNullOrEmpty(sortOrder) 
            || sortOrder == "asc" 
            || sortOrder == "desc")
            .WithMessage("SortOrder must be either 'asc', 'desc', or null.");
    }
}