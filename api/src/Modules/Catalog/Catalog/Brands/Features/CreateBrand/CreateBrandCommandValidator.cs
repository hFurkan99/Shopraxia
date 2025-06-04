namespace Catalog.Brands.Features.CreateBrand;

public class CreateBrandCommandValidator 
    : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.BrandPayload.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Brand name is required and must be less than 200 characters long.");

        RuleFor(x => x.BrandPayload.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Brand slug is required and must be less than 200 characters long.");

        RuleFor(x => x.BrandPayload.Description)
            .MaximumLength(1000)
            .WithMessage("Brand description must be less than 1000 characters long.");
    }
}
