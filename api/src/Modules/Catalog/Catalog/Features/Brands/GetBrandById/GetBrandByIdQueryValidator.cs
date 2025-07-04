namespace Catalog.Features.Brands.GetBrandById;

public class GetBrandByIdQueryValidator 
    : AbstractValidator<GetBrandByIdQuery>
{
    public GetBrandByIdQueryValidator()
    {
        RuleFor(x => x.BrandId)
            .NotEmpty()
            .WithMessage("Brand ID is required.");
    }
}