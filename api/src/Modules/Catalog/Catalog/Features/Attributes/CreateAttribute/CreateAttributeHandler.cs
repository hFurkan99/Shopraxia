namespace Catalog.Features.Attributes.CreateAttribute;

public record CreateAttributeCommand(string Name, Guid CategoryId)
    : ICommand<CreateAttributeResult>;

public record CreateAttributeResult(Guid Id);

public class CreateAttributeHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<CreateAttributeCommand, CreateAttributeResult>
{
    public async Task<CreateAttributeResult> Handle(
        CreateAttributeCommand command,
        CancellationToken cancellationToken)
    {
        var newAttribute = CreateNewAttribute(command.Name, command.CategoryId);
        await unitOfWork.Attributes.AddAsync(newAttribute, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return new CreateAttributeResult(newAttribute.Id);
    }
    private static Attribute CreateNewAttribute(string name, Guid categoryId)
    {
        var attribute = Attribute.Create(name, categoryId);
        return attribute;
    }
}