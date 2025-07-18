﻿namespace Catalog.Features.Attributes.CreateAttribute;

public class CreateAttributeCommandValidator
    : AbstractValidator<CreateAttributeCommand>
{
    public CreateAttributeCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .WithMessage("Attribute name is required and must be less than 200 characters long.");

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID is required.");
    }
}
