namespace Catalog.Features.Brands.GetBrandById;

//public record GetBrandByIdRequest(Guid BrandId);
public record GetBrandByIdResponse(
    Guid Id, 
    string Name, 
    string Slug, 
    string? Description);

public class GetBrandByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/brands/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetBrandByIdQuery(id);
            var result = await sender.Send(query);
            var response = new GetBrandByIdResponse(result.Id, result.Name, result.Slug, result.Description);
            return Results.Ok(response);
        })
        .WithName("GetBrandById")
        .Produces<GetBrandByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Brand By Id")
        .WithDescription("Get brand details by ID");
    }
}