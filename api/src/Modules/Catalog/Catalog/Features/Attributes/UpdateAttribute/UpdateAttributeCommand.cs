namespace Catalog.Features.Attributes.UpdateAttribute;

public record UpdateAttributeCommand(UpdateAttributePayload AttributePayload) 
    : ICommand<UpdateAttributeResult>;

public record UpdateAttributeResult(bool IsSuccess);