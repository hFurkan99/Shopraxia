namespace Catalog.Features.Attributes.UpdateAttribute;

public class UpdateAttributeCommandValidator 
    : AbstractValidator<UpdateAttributeCommand>
{
    public UpdateAttributeCommandValidator()
    {
        RuleFor(x => x.AttributePayload.Id)
            .NotEmpty()
            .WithMessage("Attribute ID is required.");

        RuleFor(x => x.AttributePayload.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Attribute name is required and must be less than 200 characters long.");
    }
}