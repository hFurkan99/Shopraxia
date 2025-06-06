namespace Catalog.Domain.BrandAggregate.Exceptions;

public class BrandNotFoundException(Guid id) 
    : NotFoundException("Brand", id) { }

public class BrandSlugNotFoundException(string slug)
    : NotFoundException("Brand", slug) { }
