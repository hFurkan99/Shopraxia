namespace Catalog.Features.Attributes.DeleteAttribute;

public class DeleteAttributeCommandValidator 
    : AbstractValidator<DeleteAttributeCommand>
{
    public DeleteAttributeCommandValidator()
    {
        RuleFor(x => x.AttributeId)
            .NotEmpty()
            .WithMessage("Attribute ID is required.");
    }
}