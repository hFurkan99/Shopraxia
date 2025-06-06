using Catalog.Categories.Features.GetCategories;

namespace Catalog.Features.Categories.GetCategories;

public record GetCategoriesRequest(GetCategoriesPayload CategoriesPayload);
public record GetCategoriesResponse(PaginatedResult<CategoryDto> Categories);

public class GetCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories", async ([AsParameters] GetCategoriesPayload payload ,ISender sender) =>
        {
            var query = new GetCategoriesQuery(payload);
            var result = await sender.Send(query);
            var response = new GetCategoriesResponse(result.Categories);
            return Results.Ok(response);
        })
        .WithName("GetCategories")
        .Produces<GetCategoriesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Categories")
        .WithDescription("Get all categories");
    }
}       