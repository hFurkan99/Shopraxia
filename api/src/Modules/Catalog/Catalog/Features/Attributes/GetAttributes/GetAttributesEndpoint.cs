namespace Catalog.Features.Attributes.GetAttributes;

public record GetAttributesRequest();
public record GetAttributesResponse(List<AttributeDto> Attributes);

public class GetAttributesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/attributes", async (ISender sender) =>
        {
            var query = new GetAttributesQuery();
            var result = await sender.Send(query);
            var response = result.Adapt<GetAttributesResponse>();
            return Results.Ok(response);
        })
        .WithName("GetAttributes")
        .Produces<GetAttributesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Attributes")
        .WithDescription("Get all attributes");
    }
}   