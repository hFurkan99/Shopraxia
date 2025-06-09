namespace Catalog.Features.Brands.CreateBrand;

public class CreateBrandCommandValidator 
    : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Brand name is required and must be less than 200 characters long.");

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Brand slug is required and must be less than 200 characters long.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Brand description must be less than 1000 characters long.");
    }
}
