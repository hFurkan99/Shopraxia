﻿namespace Catalog.Features.Attributes.DeleteAttribute;

public record DeleteAttributeCommand(Guid AttributeId)
    : ICommand<DeleteAttributeResult>;

public record DeleteAttributeResult(bool IsSuccess);
internal class DeleteAttributeHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteAttributeCommand, DeleteAttributeResult>
{
    public async Task<DeleteAttributeResult> Handle(
        DeleteAttributeCommand command,
        CancellationToken cancellationToken)
    {
        var attribute = await unitOfWork.Attributes
            .GetByIdAsync(command.AttributeId, cancellationToken)
            ?? throw new AttributeNotFoundException(command.AttributeId);

        unitOfWork.Attributes.Delete(attribute);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteAttributeResult(true);
    }
}