namespace Basket.Domain.BasketAggregate;

public interface IBasketRepository : IGenericRepository<ShoppingCart, Guid>
{
    Task<ShoppingCart?> GetBasketByUserIdAsync(Guid userId, 
        CancellationToken cancellationToken = default);
}
