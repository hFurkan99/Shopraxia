namespace Catalog.Products.Features.GetProducts;

internal class GetProductsHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query,
        CancellationToken cancellationToken)
    {
        var products = await unitOfWork.Products
            .GetFilteredProductsAsync(query.ProductsPayload, cancellationToken);

        var productsDto = products.Data.Adapt<List<ProductDto>>();
        var totalCount = products.TotalCount;

        return new GetProductsResult(
            new PaginatedResult<ProductDto>(
                query.ProductsPayload.Page,
                query.ProductsPayload.PageSize,
                totalCount,
                productsDto));
    }
}