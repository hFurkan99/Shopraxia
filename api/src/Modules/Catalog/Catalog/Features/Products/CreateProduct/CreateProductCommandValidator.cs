namespace Catalog.Features.Products.CreateProduct;

public class CreateProductCommandValidator
    : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Product name is required and must beless than 200 characters long.");

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Product slug is required and must be less than 200 characters long.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Product description must be less than 1000 characters long.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("Product rating must be between 0 and 5.");

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID is required.");

        RuleFor(x => x.BrandId)
            .NotEmpty()
            .WithMessage("Brand ID is required.");

        RuleForEach(x => x.Variants)
            .ChildRules(variant =>
            {
                variant.RuleFor(v => v.Sku)
                    .NotEmpty()
                    .MaximumLength(200)
                    .WithMessage("Variant name is required and must be less than 200 characters long.");

                variant.RuleFor(v => v.Price)
                    .GreaterThan(0)
                    .WithMessage("Variant price must be greater than 0.");

                variant.RuleFor(v => v.Stock)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Variant stock must be greater than or equal to 0.");


                variant.RuleForEach(v => v.VariantAttributes)
                .ChildRules(variantAttribute =>
                {
                    variantAttribute.RuleFor(va => va.Value)
                        .NotEmpty()
                        .MaximumLength(200)
                        .WithMessage("Attribute value is required and must be less than 200 characters long.");
                });

                variant.RuleForEach(v => v.Images)
                .ChildRules(variantAttribute =>
                {
                    variantAttribute.RuleFor(i => i.Url)
                        .NotEmpty()
                        .WithMessage("Image URL is required.");

                    variantAttribute.RuleFor(i => i.AltText)
                        .MaximumLength(200)
                        .WithMessage("Image alt text must be less than 200 characters long.");

                    variantAttribute.RuleFor(i => i.SortOrder)
                        .GreaterThanOrEqualTo(0)
                        .WithMessage("Image sort order must be greater than or equal to 0.");
                });
            });
    }
}