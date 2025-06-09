namespace Catalog.Infrastructure.Persistence.Repositories;

public class AttributeRepository(CatalogDbContext context)
    : GenericRepository<Attribute, Guid>(context), IAttributeRepository { }