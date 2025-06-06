namespace Catalog.Features.Attributes.CreateAttribute;

public record CreateAttributeCommand(CreateAttributePayload AttributePayload)
    : ICommand<CreateAttributeResult>;

public record CreateAttributeResult(Guid Id);
