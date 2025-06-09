namespace Catalog.Features.Attributes.UpdateAttribute;

public record UpdateAttributeCommand(Guid Id, string Name, Guid CategoryId)
    : ICommand<UpdateAttributeResult>;

public record UpdateAttributeResult(bool IsSuccess);

internal class UpdateAttributeHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<UpdateAttributeCommand, UpdateAttributeResult>
{
    public async Task<UpdateAttributeResult> Handle(
        UpdateAttributeCommand command,
        CancellationToken cancellationToken)
    {
        var attribute = await unitOfWork.Attributes
            .GetByIdAsync(command.Id, cancellationToken)
            ?? throw new AttributeNotFoundException(command.Id);

        UpdateAttribute(attribute, command.Name, command.CategoryId);

        unitOfWork.Attributes.Update(attribute);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new UpdateAttributeResult(true);
    }

    private static void UpdateAttribute(Attribute attribute, string name, Guid categoryId)
    {
        attribute.Update(name, categoryId);
    }
}