namespace Catalog.Domain.Common;

public interface IUnitOfWork
{
    IProductRepository Products { get; }
    IBrandRepository Brands { get; }
    ICategoryRepository Categories { get; }
    IAttributeRepository Attributes { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}