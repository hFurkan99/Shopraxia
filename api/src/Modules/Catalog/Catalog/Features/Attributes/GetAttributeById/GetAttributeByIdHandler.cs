using Catalog.Domain.Common;

namespace Catalog.Features.Attributes.GetAttributeById;

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