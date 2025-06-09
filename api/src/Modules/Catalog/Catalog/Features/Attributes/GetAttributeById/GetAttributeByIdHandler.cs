namespace Catalog.Features.Attributes.GetAttributeById;

public record GetAttributeByIdQuery(Guid AttributeId)
    : IQuery<GetAttributeByIdResult>;

public record GetAttributeByIdResult(
    Guid Id,
    string Name);

internal class GetAttributeByIdHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetAttributeByIdQuery, GetAttributeByIdResult>
{
    public async Task<GetAttributeByIdResult> Handle(
        GetAttributeByIdQuery query,
        CancellationToken cancellationToken)
    {
        var attribute = await unitOfWork.Attributes
            .GetByIdAsync(query.AttributeId, cancellationToken)
            ?? throw new AttributeNotFoundException(query.AttributeId);

        return new GetAttributeByIdResult(
            attribute.Id,
            attribute.Name);
    }
}