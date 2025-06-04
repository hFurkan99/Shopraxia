using Catalog.Data.Repositories.Brands;
using Catalog.Data.Repositories.Categories;
using Catalog.Data.Repositories.Products;

namespace Catalog.Data.UnitOfWork;

public class UnitOfWork(CatalogDbContext context, 
    IProductRepository productRepository,
    IBrandRepository brandRepository,
    ICategoryRepository categoryRepository) : IUnitOfWork
{
    private readonly CatalogDbContext _context = context;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IBrandRepository _brandRepository = brandRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public IProductRepository Products => _productRepository;
    public IBrandRepository Brands => _brandRepository;
    public ICategoryRepository Categories => _categoryRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}