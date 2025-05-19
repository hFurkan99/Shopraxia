namespace Catalog.Products.Exceptions;

public class ProductNotFoundException(Guid id) 
    : NotFoundException("Product", id) { }

public class ProductSlugNotFoundException(string slug)
    : NotFoundException("Product", slug) { }