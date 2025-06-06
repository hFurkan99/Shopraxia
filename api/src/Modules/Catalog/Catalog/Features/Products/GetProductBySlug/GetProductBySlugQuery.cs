namespace Catalog.Features.Products.GetProductBySlug;

public record GetProductBySlugQuery(string Slug)
    : IQuery<GetProductBySlugResult>;

public record GetProductBySlugResult(ProductDto Product);