using Catalog.Data.Repositories.Products;
using Catalog.Data.Repositories.Brands;
using Catalog.Data.Repositories.Categories;

namespace Catalog.Data.UnitOfWork;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    IBrandRepository Brands { get; }
    ICategoryRepository Categories { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}