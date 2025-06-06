namespace Catalog.Features.Categories.GetCategoryBySlug;

public class GetCategoryBySlugQueryValidator 
    : AbstractValidator<GetCategoryBySlugQuery>
{
    public GetCategoryBySlugQueryValidator()
    {
        RuleFor(x => x.Slug)
            .NotEmpty()
            .WithMessage("Category slug is required.");
    }
}   