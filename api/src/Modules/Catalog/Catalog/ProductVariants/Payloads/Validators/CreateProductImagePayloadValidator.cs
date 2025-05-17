namespace Catalog.ProductVariants.Payloads.Validators;

public class CreateProductImagePayloadValidator
    : AbstractValidator<CreateProductImagePayload>
{
    public CreateProductImagePayloadValidator()
    {
        RuleFor(x => x.Url)
            .NotEmpty()
            .WithMessage("Image URL is required");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0)
            .WithMessage("SortOrder must be 0 or more");
    }
}
