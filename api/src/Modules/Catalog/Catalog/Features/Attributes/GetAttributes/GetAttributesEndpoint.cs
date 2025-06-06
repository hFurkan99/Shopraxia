using Catalog.Attributes.Features.GetAttributes;

namespace Catalog.Features.Attributes.GetAttributes;

public record GetAttributesRequest();
public record GetAttributesResponse(Guid Id, string Name);

public class GetAttributesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/attributes", async (ISender sender) =>
        {
            var query = new GetAttributesQuery();
            var result = await sender.Send(query);
            var response = new GetAttributesResponse(result.Attributes);
            return Results.Ok(response);
        })
        .WithName("GetAttributes")
        .Produces<GetAttributesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Attributes")
        .WithDescription("Get all attributes");
    }
}   