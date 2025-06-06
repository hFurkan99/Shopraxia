namespace Catalog.Domain.AttributeAggregate.Exceptions;

public class AttributeNotFoundException(Guid id) 
    : NotFoundException("Attribute", id) { }
