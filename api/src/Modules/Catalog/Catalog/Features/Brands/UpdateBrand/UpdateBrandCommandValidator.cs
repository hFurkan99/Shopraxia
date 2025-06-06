namespace Catalog.Features.Brands.UpdateBrand;

public class UpdateBrandCommandValidator 
    : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(x => x.BrandPayload.Id)
            .NotEmpty()
            .WithMessage("Brand ID is required.");

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