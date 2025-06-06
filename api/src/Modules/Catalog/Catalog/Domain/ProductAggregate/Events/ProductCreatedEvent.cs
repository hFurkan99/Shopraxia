namespace Catalog.Domain.ProductAggregate.Events;

public record ProductCreatedEvent(Product Product) : IDomainEvent;