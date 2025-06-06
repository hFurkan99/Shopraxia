using Catalog.Domain.AttributeAggregate;
using Catalog.Domain.BrandAggregate;
using Catalog.Domain.CategoryAggregate;
using Catalog.Domain.Common;
using Catalog.Domain.ProductAggregate;

namespace Catalog.Infrastructure.Persistence;

public class UnitOfWork(CatalogDbContext context, 
    IProductRepository productRepository,
    IBrandRepository brandRepository,
    ICategoryRepository categoryRepository,
    IAttributeRepository attributeRepository) 
    : IUnitOfWork
{
    private readonly CatalogDbContext _context = context;
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IBrandRepository _brandRepository = brandRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IAttributeRepository _attributeRepository = attributeRepository;


    public IProductRepository Products => _productRepository;
    public IBrandRepository Brands => _brandRepository;
    public ICategoryRepository Categories => _categoryRepository;
    public IAttributeRepository Attributes => _attributeRepository;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}