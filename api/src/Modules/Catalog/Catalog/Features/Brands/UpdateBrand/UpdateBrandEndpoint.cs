namespace Catalog.Features.Brands.UpdateBrand;

public record UpdateBrandRequest(
    Guid Id,
    string Name,
    string Slug,
    string? Description);

public record UpdateBrandResponse(bool IsSuccess);

public class UpdateBrandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/brands", async (UpdateBrandRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateBrandCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdateBrandResponse>();
            return Results.Ok(response);
        })
        .WithName("UpdateBrand")
        .Produces<UpdateBrandResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Brand")
        .WithDescription("Update brand by ID");
    }
}   