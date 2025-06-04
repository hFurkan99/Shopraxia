namespace Catalog.Brands.Features.DeleteBrand;

//public record DeleteBrandRequest(Guid BrandId);
public record DeleteBrandResponse(bool IsSuccess);

public class DeleteBrandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/brands/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteBrandCommand(id);
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteBrandResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteBrand")
        .Produces<DeleteBrandResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Brand")
        .WithDescription("Delete Brand by ID");
    }
}