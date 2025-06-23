namespace Basket.Domain.Common;

public interface IUnitOfWork
{
    IBasketRepository Baskets { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
