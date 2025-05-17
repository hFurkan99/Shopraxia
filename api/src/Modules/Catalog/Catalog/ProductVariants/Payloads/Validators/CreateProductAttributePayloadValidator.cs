namespace Catalog.ProductVariants.Payloads.Validators;

public class CreateProductAttributePayloadValidator
    : AbstractValidator<CreateProductAttributePayload>
{
    public CreateProductAttributePayloadValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Attribute name is required");

        RuleFor(x => x.Value)
            .NotEmpty()
            .WithMessage("Attribute value is required");
    }
}
