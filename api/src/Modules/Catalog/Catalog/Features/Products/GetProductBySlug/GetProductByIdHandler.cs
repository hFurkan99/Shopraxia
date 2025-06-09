namespace Catalog.Features.Products.GetProductBySlug;

public record GetProductBySlugQuery(string Slug)
    : IQuery<GetProductBySlugResult>;

public record GetProductBySlugResult(ProductDto Product);

internal class GetProductByIdHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetProductBySlugQuery, GetProductBySlugResult>
{
    public async Task<GetProductBySlugResult> Handle(
        GetProductBySlugQuery query, 
        CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products
            .GetProductWithVariantsBySlug(query.Slug, cancellationToken)
            ?? throw new ProductSlugNotFoundException(query.Slug);

        var productDto = product.Adapt<ProductDto>();

        return new GetProductBySlugResult(productDto);
    }
}