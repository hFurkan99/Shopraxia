namespace Basket.Features.Baskets.GetBasket;

public record GetBasketQuery(Guid UserId) 
    : IQuery<GetBasketResult>;

public record GetBasketResult(Guid ShoppingCartId, Guid UserId, decimal TotalPrice,
    IReadOnlyList<ShoppingCartItemDto> Items);

internal class GetBasketHandler
    (IUnitOfWork unitOfWork, ISender sender)
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, 
        CancellationToken cancellationToken)
    {
        var shoppingCart = await unitOfWork.Baskets
            .GetBasketByUserIdAsync(query.UserId, cancellationToken) 
            ?? throw new NotFoundException("Shopping cart not found.");

        if (shoppingCart.UserId != query.UserId)
            throw new UnauthorizedAccessException("You do not have permission " +
                "to view this shopping cart.");

        var items = new List<ShoppingCartItemDto>();

        foreach (var item in shoppingCart.Items)
        {
            var itemDto = await MapToDto(item);
            items.Add(itemDto);
        }

        return new GetBasketResult(
            shoppingCart.Id,
            shoppingCart.UserId,
            shoppingCart.TotalPrice,
            items);
    }

    private async Task<ShoppingCartItemDto> MapToDto(ShoppingCartItem item)
    {
        var product = await sender.Send(new GetProductByIdQuery(item.ProductId)) 
            ?? throw new NotFoundException("Product not found.", item.ProductId);

        var productVariant = product.Product.Variants
            .FirstOrDefault(v => v.Id == item.VariantId) 
            ?? throw new NotFoundException("Product variant not found.", item.VariantId!.Value);

        return new ShoppingCartItemDto(
            item.Id,
            item.ProductId,
            item.VariantId,
            item.Quantity,
            item.UnitPrice,
            product.Product.Name,
            productVariant.Sku);
    }
}