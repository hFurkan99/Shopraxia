namespace Catalog.Features.Products.GetProducts;

public class GetProductsQueryValidator 
    : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {
        RuleFor(x => x.ProductsPayload.Page)
            .GreaterThan(0);

        RuleFor(x => x.ProductsPayload.PageSize)
            .InclusiveBetween(1, 100);

        RuleFor(x => x.ProductsPayload.SortBy)
            .Must(sortBy => string.IsNullOrEmpty(sortBy) 
            || sortBy == "name" 
            || sortBy == "price" 
            || sortBy == "rating")
            .WithMessage("SortBy must be either 'name', 'price', or null.");    

        RuleFor(x => x.ProductsPayload.SortOrder)
            .Must(sortOrder => string.IsNullOrEmpty(sortOrder) 
            || sortOrder == "asc" 
            || sortOrder == "desc")
            .WithMessage("SortOrder must be either 'asc', 'desc', or null.");
    }
}