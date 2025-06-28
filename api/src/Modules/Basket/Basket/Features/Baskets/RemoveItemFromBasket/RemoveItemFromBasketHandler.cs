namespace Basket.Features.Baskets.RemoveItemFromBasket;

public record RemoveItemFromBasketCommand(
    Guid UserId,
    Guid ProductId,
    Guid? ProductVariantId,
    int Quantity) 
    : ICommand<RemoveItemFromBasketResult>;

public record RemoveItemFromBasketResult(Guid Id);

internal class RemoveItemFromBasketHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<RemoveItemFromBasketCommand, RemoveItemFromBasketResult>
{
    public async Task<RemoveItemFromBasketResult> Handle(RemoveItemFromBasketCommand command, 
        CancellationToken cancellationToken)
    {
        var shoppingCart = await unitOfWork.Baskets
            .GetBasketByUserIdAsync(command.UserId, cancellationToken) 
            ?? throw new InvalidOperationException("Shopping cart not found.");

        if (shoppingCart.UserId != command.UserId)
            throw new UnauthorizedAccessException("You do not have permission " +
                "to modify this shopping cart.");

        await RemoveItemFromCartAsync(
            shoppingCart, 
            command.ProductId, 
            command.ProductVariantId, 
            command.Quantity, 
            cancellationToken);

        return new RemoveItemFromBasketResult(shoppingCart.Id);
    }

    private async Task RemoveItemFromCartAsync(
        ShoppingCart shoppingCart, 
        Guid productId, 
        Guid? productVariantId, 
        int quantity,
        CancellationToken cancellationToken)
    {
        shoppingCart.RemoveItem(productId, productVariantId, quantity);
        unitOfWork.Baskets.Update(shoppingCart);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}