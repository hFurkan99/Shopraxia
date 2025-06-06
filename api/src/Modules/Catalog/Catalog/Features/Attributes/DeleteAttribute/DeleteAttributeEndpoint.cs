namespace Catalog.Features.Attributes.DeleteAttribute;

//public record DeleteAttributeRequest(Guid AttributeId);
public record DeleteAttributeResponse(bool IsSuccess);

public class DeleteAttributeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/attributes/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteAttributeCommand(id);
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteAttributeResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteAttribute")
        .Produces<DeleteAttributeResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Attribute")
        .WithDescription("Delete Attribute by ID");
    }
}