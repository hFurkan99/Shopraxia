namespace Catalog.Features.Attributes.UpdateAttribute;

public record UpdateAttributeRequest(UpdateAttributePayload AttributePayload);
public record UpdateAttributeResponse(bool IsSuccess);

public class UpdateAttributeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/attributes", async (UpdateAttributeRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateAttributeCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdateAttributeResponse>();
            return Results.Ok(response);
        })
        .WithName("UpdateAttribute")
        .Produces<UpdateAttributeResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Attribute")
        .WithDescription("Update attribute by ID");
    }
}   