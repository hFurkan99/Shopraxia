namespace Catalog.Features.Attributes.DeleteAttribute;

public record DeleteAttributeCommand(Guid AttributeId) 
    : ICommand<DeleteAttributeResult>;

public record DeleteAttributeResult(bool IsSuccess);