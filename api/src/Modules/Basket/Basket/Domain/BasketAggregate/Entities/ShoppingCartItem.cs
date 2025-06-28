namespace Basket.Domain.BasketAggregate.Entities;

public class ShoppingCartItem : Entity<Guid>
{
    public Guid ShoppingCartId { get; private set; }
    public Guid ProductId { get; private set; }
    public Guid? VariantId { get; private set; }
    public int Quantity { get; internal set; }
    public decimal UnitPrice { get; private set; }

    public ShoppingCartItem() { }

    internal ShoppingCartItem(
        Guid shoppingCartId, 
        Guid productId, 
        Guid? variantId, 
        int quantity, 
        decimal unitPrice)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(quantity);
        ArgumentOutOfRangeException.ThrowIfNegative(unitPrice);
        GuidGuard.AgainstEmptyGuid(shoppingCartId, nameof(shoppingCartId));
        GuidGuard.AgainstEmptyGuid(productId, nameof(productId));

        ShoppingCartId = shoppingCartId;
        ProductId = productId;
        VariantId = variantId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }

    public void IncreaseQuantity(int amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        Quantity += amount;
    }

    public void DecreaseQuantity(int amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
        if (Quantity - amount >= 0) Quantity -= amount;
        else Quantity = 0;
    }

    public void SetQuantity(int newQuantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(newQuantity);
        Quantity = newQuantity;
    }

    public void UpdateUnitPrice(decimal newUnitPrice)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(newUnitPrice);
        UnitPrice = newUnitPrice;
    }
}
