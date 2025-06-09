namespace Catalog.Features.Attributes.CreateAttribute;

public record CreateAttributeRequest(string Name, Guid CategoryId);
public record CreateAttributeResponse(Guid Id);

public class CreateAttributeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Attributes", async (CreateAttributeRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateAttributeCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateAttributeResponse>();
            return Results.Created($"/Attributes/{response.Id}", response);
        })
        .WithName("CreateAttribute")
        .Produces<CreateAttributeResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Attribute")
        .WithDescription("Create Attribute");
    }
}