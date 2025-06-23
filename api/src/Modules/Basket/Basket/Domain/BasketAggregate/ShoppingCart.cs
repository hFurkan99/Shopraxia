namespace Basket.Domain.BasketAggregate;

public class ShoppingCart : Aggregate<Guid>
{
    public Guid UserId { get; private set; }

    private readonly List<ShoppingCartItem> _items = [];
    public IReadOnlyList<ShoppingCartItem> Items => _items.AsReadOnly();
    public decimal TotalPrice => _items.Sum(i => i.UnitPrice * i.Quantity);

    public DateTime? CheckedOutAt { get; private set; }
    public bool IsCheckedOut => CheckedOutAt.HasValue;

    public static ShoppingCart Create(Guid id, Guid userId)
    {
        GuidGuard.AgainstEmptyGuid(id, nameof(id));
        GuidGuard.AgainstEmptyGuid(userId, nameof(userId));

        var shoppingCart = new ShoppingCart
        {
            Id = id,
            UserId = userId
        };
        return shoppingCart;
    }

    public void AddItem(Guid productId, Guid? variantId, int quantity, decimal price)
    {
        if (IsCheckedOut)
            throw new InvalidOperationException("Cannot modify a checked out cart.");

        var existing = _items.FirstOrDefault(i => i.ProductId == productId && i.VariantId == variantId);

        if (existing != null)
        {
            existing.IncreaseQuantity(quantity);
        }
        else
        {
            _items.Add(new ShoppingCartItem(Id, productId, variantId, quantity, price));
        }
    }

    public void RemoveItem(Guid productId, Guid? variantId, int quantity)
    {
        if (IsCheckedOut)
            throw new InvalidOperationException("Cannot modify a checked out cart.");

        var item = _items.FirstOrDefault(i => i.ProductId == productId && i.VariantId == variantId)
            ?? throw new NotFoundException("product", productId);
        
        item.DecreaseQuantity(quantity);

        if(item.Quantity <= 0) _items.Remove(item);
    }

    public void UpdateItemQuantity(Guid productId, Guid? variantId, int newQuantity)
    {
        if (IsCheckedOut)
            throw new InvalidOperationException("Cannot modify a checked out cart.");

        var item = _items.FirstOrDefault(i => i.ProductId == productId && i.VariantId == variantId) 
            ?? throw new NotFoundException("product", productId);

        if (newQuantity <= 0)
            _items.Remove(item);
        else
            item.SetQuantity(newQuantity);
    }

    public void Clear()
    {
        if (IsCheckedOut)
            throw new InvalidOperationException("Cannot modify a checked out cart.");

        _items.Clear();
    }

    public void UpdateItemPrice(Guid productId, Guid? variantId, decimal newPrice)
    {
        if (IsCheckedOut)
            throw new InvalidOperationException("Cannot modify a checked out cart.");

        var item = _items.FirstOrDefault(i => i.ProductId == productId && i.VariantId == variantId) 
            ?? throw new NotFoundException("product", productId);

        item.UpdateUnitPrice(newPrice);
    }
}
