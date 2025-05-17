namespace Catalog.ProductVariants.Payloads.Validators;

public class CreateProductVariantPayloadValidator
    : AbstractValidator<CreateProductVariantPayload>
{
    public CreateProductVariantPayloadValidator()
    {
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("SKU is required");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Variant price must be greater than 0");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock must be 0 or more");

        RuleForEach(x => x.Attributes)
            .SetValidator(new CreateProductAttributePayloadValidator())
            .WithMessage("At least one attribute is required.");

        RuleForEach(x => x.Images)
            .SetValidator(new CreateProductImagePayloadValidator())
            .WithMessage("At least one image is required.");
    }
}
