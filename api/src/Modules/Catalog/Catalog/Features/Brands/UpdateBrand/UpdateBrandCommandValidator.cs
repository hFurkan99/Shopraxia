namespace Catalog.Features.Brands.UpdateBrand;

public class UpdateBrandCommandValidator 
    : AbstractValidator<UpdateBrandCommand>
{
    public UpdateBrandCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Brand ID is required.");

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