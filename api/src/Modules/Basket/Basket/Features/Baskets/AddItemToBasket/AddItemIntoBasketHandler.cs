namespace Basket.Features.Baskets.AddItemToBasket;

public record AddItemIntoBasketCommand(
    Guid UserId,
    Guid ProductId,
    Guid? ProductVariantId,
    int Quantity) 
    : ICommand<AddItemIntoBasketResult>;  

public record AddItemIntoBasketResult(Guid Id);

internal class AddItemIntoBasketHandler
    (IUnitOfWork unitOfWork, ISender sender)
    : ICommandHandler<AddItemIntoBasketCommand, AddItemIntoBasketResult>
{
    public async Task<AddItemIntoBasketResult> Handle(AddItemIntoBasketCommand command, 
        CancellationToken cancellationToken)
    {
        var isNewCart = false;

        var shoppingCart = await unitOfWork.Baskets.
            GetBasketByUserIdAsync(command.UserId, cancellationToken);

        if(shoppingCart is null)
        {
            shoppingCart = CreateNewShoppingCart(command.UserId, Guid.NewGuid());
            isNewCart = true;
        }

        if (shoppingCart.UserId != command.UserId)
            throw new UnauthorizedAccessException("You do not have permission to modify this shopping cart.");

        await AddItemToCartAsync(shoppingCart, command.ProductId, 
            command.ProductVariantId, command.Quantity, isNewCart, cancellationToken);

        return new AddItemIntoBasketResult(shoppingCart.Id);
    }

    private static ShoppingCart CreateNewShoppingCart(Guid userId, Guid shoppingCartId)
    {
        return ShoppingCart.Create(shoppingCartId, userId);
    }

    private async Task AddItemToCartAsync(
        ShoppingCart shoppingCart, 
        Guid productId, 
        Guid? productVariantId, 
        int quantity,
        bool isNewCart,
        CancellationToken cancellationToken)
    {
        var product = await sender.Send(new GetProductByIdQuery(productId), cancellationToken);
        shoppingCart.AddItem(productId, productVariantId, quantity, product.Product.Variants[0].Price);

        if(isNewCart)
        {
            await unitOfWork.Baskets.AddAsync(shoppingCart, cancellationToken);
        }
        else
        {
            unitOfWork.Baskets.Update(shoppingCart);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);   
    }
}
