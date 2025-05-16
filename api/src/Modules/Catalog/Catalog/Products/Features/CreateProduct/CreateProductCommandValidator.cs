namespace Catalog.Products.Features.CreateProduct;
public class CreateProductCommandValidator
    : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.ProductDto.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Product name is required and must beless than 200 characters long.");

        RuleFor(x => x.ProductDto.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Product slug is required and must be less than 200 characters long.");

        RuleFor(x => x.ProductDto.Description)
            .MaximumLength(1000)
            .WithMessage("Product description is required and must be less than 1000 characters long.");

        RuleFor(x => x.ProductDto.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("Product rating must be between 0 and 5.");

        RuleFor(x => x.ProductDto.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID is required.");

        RuleFor(x => x.ProductDto.CategoryName)
            .NotEmpty()
            .WithMessage("Category name is required.");

        RuleFor(x => x.ProductDto.BrandId)
            .NotEmpty()
            .WithMessage("Brand ID is required.");

        RuleFor(x => x.ProductDto.BrandName)
            .NotEmpty()
            .WithMessage("Brand name is required.");

        RuleForEach(x => x.ProductDto.VariantDtos)
            .SetValidator(new ProductVariantDtoValidator())
            .WithMessage("At least one variant is required.");
    }
}

public class ProductVariantDtoValidator 
    : AbstractValidator<ProductVariantDto>
{
    public ProductVariantDtoValidator()
    {
        RuleFor(x => x.Sku)
            .NotEmpty()
            .WithMessage("SKU is required");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Variant price must be greater than 0");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Stock must be 0 or more");

        RuleForEach(x => x.Attributes)
            .SetValidator(new ProductAttributeDtoValidator())
            .WithMessage("At least one attribute is required.");

        RuleForEach(x => x.Images)
            .SetValidator(new ProductImageDtoValidator())
            .WithMessage("At least one image is required.");
    }
}

public class ProductAttributeDtoValidator 
    : AbstractValidator<ProductAttributeDto>
{
    public ProductAttributeDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Attribute name is required");

        RuleFor(x => x.Value)
            .NotEmpty()
            .WithMessage("Attribute value is required");
    }
}

public class ProductImageDtoValidator 
    : AbstractValidator<ProductImageDto>
{
    public ProductImageDtoValidator()
    {
        RuleFor(x => x.Url)
            .NotEmpty()
            .WithMessage("Image URL is required");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0)
            .WithMessage("SortOrder must be 0 or more");
    }
}