namespace Catalog.Features.Products.GetProductById;

public class GetProductByIdQueryValidator 
    : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID cannot be empty.");
    }
}