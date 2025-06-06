namespace Catalog.Features.Products.GetProductBySlug;

public class GetProductBySlugQueryValidator 
    : AbstractValidator<GetProductBySlugQuery>
{
    public GetProductBySlugQueryValidator()
    {
        RuleFor(x => x.Slug)
            .NotEmpty()
            .WithMessage("Product slug cannot be empty.");
    }
}