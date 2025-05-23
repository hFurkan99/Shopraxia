﻿namespace Catalog.Products.Features.CreateProduct;

public class CreateProductCommandValidator
    : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.ProductPayload.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Product name is required and must beless than 200 characters long.");

        RuleFor(x => x.ProductPayload.Slug)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Product slug is required and must be less than 200 characters long.");

        RuleFor(x => x.ProductPayload.Description)
            .MaximumLength(1000)
            .WithMessage("Product description is required and must be less than 1000 characters long.");

        RuleFor(x => x.ProductPayload.Rating)
            .InclusiveBetween(0, 5)
            .WithMessage("Product rating must be between 0 and 5.");

        //RuleFor(x => x.ProductPayload.CategoryId)
        //    .NotEmpty()
        //    .WithMessage("Category ID is required.");

        //RuleFor(x => x.ProductPayload.BrandId)
        //    .NotEmpty()
        //    .WithMessage("Brand ID is required.");

        RuleForEach(x => x.ProductPayload.Variants)
            .SetValidator(new CreateProductVariantPayloadValidator())
            .WithMessage("At least one variant is required.");
    }
}