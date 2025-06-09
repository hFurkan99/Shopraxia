namespace Catalog.Features.Products.GetProducts;

public record GetProductsQuery(
    Guid? BrandId,
    Guid? CategoryId,
    decimal? MinPrice,
    decimal? MaxPrice,
    string? Search,
    string? SortBy,
    string? SortOrder,
    int Page = 1,
    int PageSize = 10)
    : IQuery<GetProductsResult>;

public record GetProductsResult(PaginatedResult<ProductDto> Products);

internal class GetProductsHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(
        GetProductsQuery query,
        CancellationToken cancellationToken)
    {
        var products = await unitOfWork.Products
            .GetFilteredProductsAsync(query.BrandId, query.CategoryId,
            query.MinPrice, query.MaxPrice, query.Search, query.SortBy, 
            query.SortOrder, query.Page, query.PageSize, cancellationToken);

        var productsDto = products.Data.Adapt<List<ProductDto>>();
        var totalCount = products.TotalCount;

        return new GetProductsResult(
            new PaginatedResult<ProductDto>(
                query.Page,
                query.PageSize,
                totalCount,
                productsDto));
    }
}