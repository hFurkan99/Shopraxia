using Catalog.Domain.AttributeAggregate;
using Catalog.Infrastructure.Persistence;
using Attribute = Catalog.Domain.AttributeAggregate.Attribute;

namespace Catalog.Infrastructure.Repositories;

public class AttributeRepository(CatalogDbContext context)
    : GenericRepository<Attribute, Guid>(context), IAttributeRepository { }