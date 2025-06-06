namespace Catalog.Features.Attributes.GetAttributeById;

public class GetAttributeByIdQueryValidator 
    : AbstractValidator<GetAttributeByIdQuery>
{
    public GetAttributeByIdQueryValidator()
    {
        RuleFor(x => x.AttributeId)
            .NotEmpty()
            .WithMessage("Attribute ID is required.");
    }
}