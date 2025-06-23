namespace Basket.Domain.BasketAggregate.Exceptions;
public class BasketNotFoundException(Guid id)
    : NotFoundException("ShoppingCart", id)
{
}
