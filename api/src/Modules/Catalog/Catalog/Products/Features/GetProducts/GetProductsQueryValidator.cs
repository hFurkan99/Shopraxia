namespace Catalog.Products.Features.GetProducts;

public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {
        RuleFor(x => x.ProductsPayload.Page)
            .GreaterThan(0);

        RuleFor(x => x.ProductsPayload.PageSize)
            .InclusiveBetween(1, 100);

        RuleFor(x => x.ProductsPayload.SortOrder)
            .Must(o => o is null or "asc" or "desc")
            .WithMessage("SortOrder must be 'asc' or 'desc'");

        RuleFor(x => x.ProductsPayload.SortBy)
            .Must(s => s is null or "price" or "name" or "rating")
            .WithMessage("SortBy must be 'price', 'name', or 'rating'");
    }
}