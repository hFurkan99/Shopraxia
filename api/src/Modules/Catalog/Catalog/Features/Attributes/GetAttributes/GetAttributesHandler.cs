using Catalog.Domain.Common;

namespace Catalog.Features.Attributes.GetAttributes;

internal class GetAttributesHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetAttributesQuery, GetAttributesResult>
{
    public async Task<GetAttributesResult> Handle(
        GetAttributesQuery query,
        CancellationToken cancellationToken)
    {
        var attributes = await unitOfWork.Attributes
            .GetAllAsync(cancellationToken);

        var attributeDtos = attributes.Adapt<GetAttributesResult>();

        return attributeDtos;
    }
}   