namespace Catalog.Data.UnitOfWork;

public class UnitOfWork(CatalogDbContext context, 
    IProductRepository productRepository) : IUnitOfWork
{
    private readonly CatalogDbContext _context = context;
    private readonly IProductRepository _productRepository = productRepository;

    public IProductRepository Products => _productRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}