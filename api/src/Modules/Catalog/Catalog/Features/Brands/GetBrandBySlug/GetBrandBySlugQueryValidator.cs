namespace Catalog.Features.Brands.GetBrandBySlug;

public class GetBrandBySlugQueryValidator 
    : AbstractValidator<GetBrandBySlugQuery>
{
    public GetBrandBySlugQueryValidator()
    {
        RuleFor(x => x.Slug)
            .NotEmpty()
            .WithMessage("Brand slug is required.");
    }
}   