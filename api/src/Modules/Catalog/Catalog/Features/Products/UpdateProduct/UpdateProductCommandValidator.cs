namespace Catalog.Features.Products.UpdateProduct;

public class UpdateProductCommandValidator
    : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Product name is required and must be less than 200 characters long.");

        RuleFor(x => x.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Product slug is required and must be less than 200 characters long.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .WithMessage("Product description is required and must be less than 1000 characters long.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("Product rating must be between 0 and 5.");

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID is required.");

        RuleFor(x => x.BrandId)
            .NotEmpty()
            .WithMessage("Brand ID is required.");
    }
}