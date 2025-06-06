using Catalog.Attributes.Features.GetAttributeById;

namespace Catalog.Features.Attributes.GetAttributeById;

//public record GetAttributeByIdRequest(Guid AttributeId);
public record GetAttributeByIdResponse(Guid Id, string Name);

public class GetAttributeByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/attributes/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetAttributeByIdQuery(id);
            var result = await sender.Send(query);
            var response = new GetAttributeByIdResponse(result.Id, result.Name);
            return Results.Ok(response);
        })
        .WithName("GetAttributeById")
        .Produces<GetAttributeByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Attribute By Id")
        .WithDescription("Get attribute details by ID");
    }
}