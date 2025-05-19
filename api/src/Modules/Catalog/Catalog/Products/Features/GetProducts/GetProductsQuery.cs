namespace Catalog.Products.Features.GetProducts;

public record GetProductsQuery(GetProductsPayload ProductsPayload)
    : IQuery<GetProductsResult>;

public record GetProductsResult(PaginatedResult<ProductDto> Products);