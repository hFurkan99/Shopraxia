using Catalog.Domain.Common;
using Attribute = Catalog.Domain.AttributeAggregate.Attribute;

namespace Catalog.Features.Attributes.CreateAttribute;

public class CreateAttributeHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAttributeCommand, CreateAttributeResult>
{
    public async Task<CreateAttributeResult> Handle(
        CreateAttributeCommand command,
        CancellationToken cancellationToken)
    {
        var attributePayload = command.AttributePayload;
        var newAttribute = CreateNewAttribute(attributePayload);
        await unitOfWork.Attributes.AddAsync(newAttribute, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateAttributeResult(newAttribute.Id);
    }
    private static Attribute CreateNewAttribute(CreateAttributePayload attributePayload)
    {
        var attribute = Attribute.Create(attributePayload);
        return attribute;
    }
}