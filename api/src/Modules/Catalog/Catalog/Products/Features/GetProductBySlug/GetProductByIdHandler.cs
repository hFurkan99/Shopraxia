namespace Catalog.Products.Features.GetProductBySlug;

internal class GetProductByIdHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetProductBySlugQuery, GetProductBySlugResult>
{
    public async Task<GetProductBySlugResult> Handle(GetProductBySlugQuery query, 
        CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products
            .GetProductWithVariantsBySlug(query.Slug, cancellationToken)
            ?? throw new ProductSlugNotFoundException(query.Slug);

        var productDto = product.Adapt<ProductDto>();

        return new GetProductBySlugResult(productDto);
    }
}