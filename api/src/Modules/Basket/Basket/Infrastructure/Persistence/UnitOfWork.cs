namespace Basket.Infrastructure.Persistence;

public class UnitOfWork(BasketDbContext context,
    IBasketRepository basketRepository)
    : IUnitOfWork
{
    private readonly BasketDbContext _context = context;
    private readonly IBasketRepository _basketRepository = basketRepository;


    public IBasketRepository Baskets => _basketRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}