namespace Catalog.Categories.Exceptions;

public class CategoryNotFoundException(Guid id) 
    : NotFoundException("Category", id) { }

public class CategorySlugNotFoundException(string slug)
    : NotFoundException("Category", slug) { }