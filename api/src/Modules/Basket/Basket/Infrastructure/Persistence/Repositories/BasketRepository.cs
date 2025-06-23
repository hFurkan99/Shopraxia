namespace Basket.Infrastructure.Persistence.Repositories;

public class BasketRepository(BasketDbContext context)
    : GenericRepository<ShoppingCart, Guid>(context), IBasketRepository
{
    public async Task<ShoppingCart?> GetBasketByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
    {
        return await _context.ShoppingCarts
            .Include(b => b.Items)
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.UserId == userId, cancellationToken);
    }
}
