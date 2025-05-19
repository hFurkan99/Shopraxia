namespace Catalog.Products.Features.GetProductById;

internal class GetProductByIdHandler(IUnitOfWork unitOfWork) 
    : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, 
        CancellationToken cancellationToken)
    {
        var product = await unitOfWork.Products.
            GetProductWithVariantsById(query.ProductId, cancellationToken)
            ?? throw new ProductNotFoundException(query.ProductId);

        var productDto = product.Adapt<ProductDto>();

        return new GetProductByIdResult(productDto);
    }
}