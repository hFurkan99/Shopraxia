namespace Catalog.Features.Brands.DeleteBrand;

public class DeleteBrandCommandValidator 
    : AbstractValidator<DeleteBrandCommand>
{
    public DeleteBrandCommandValidator()
    {
        RuleFor(x => x.BrandId)
            .NotEmpty()
            .WithMessage("Brand ID is required.");
    }
}