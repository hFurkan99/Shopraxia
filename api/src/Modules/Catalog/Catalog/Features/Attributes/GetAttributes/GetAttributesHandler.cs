namespace Catalog.Features.Attributes.GetAttributes;

public record GetAttributesQuery()
    : IQuery<GetAttributesResult>;

public record GetAttributesResult(List<AttributeDto> Attributes);

internal class GetAttributesHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetAttributesQuery, GetAttributesResult>
{
    public async Task<GetAttributesResult> Handle(
        GetAttributesQuery query,
        CancellationToken cancellationToken)
    {
        var attributes = await unitOfWork.Attributes
            .GetAllAsync(cancellationToken);

        var attributeDtos = attributes.Adapt<List<AttributeDto>>();

        return new GetAttributesResult(attributeDtos);
    }
}   