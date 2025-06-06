using Catalog.Domain.Common;
using Attribute = Catalog.Domain.AttributeAggregate.Attribute
    ;
namespace Catalog.Features.Attributes.UpdateAttribute;

internal class UpdateAttributeHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateAttributeCommand, UpdateAttributeResult>
{
    public async Task<UpdateAttributeResult> Handle(
        UpdateAttributeCommand command,
        CancellationToken cancellationToken)
    {
        var attribute = await unitOfWork.Attributes
            .GetByIdAsync(command.AttributePayload.Id, cancellationToken)
            ?? throw new AttributeNotFoundException(command.AttributePayload.Id);

        UpdateAttribute(attribute, command.AttributePayload);

        unitOfWork.Attributes.Update(attribute);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateAttributeResult(true);
    }

    private static void UpdateAttribute(Attribute attribute, UpdateAttributePayload attributePayload)
    {
        attribute.Update(attributePayload);
    }
}