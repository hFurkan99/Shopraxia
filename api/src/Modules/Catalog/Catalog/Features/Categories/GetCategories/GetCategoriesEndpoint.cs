namespace Catalog.Features.Categories.GetCategories;

public record GetCategoriesRequest(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string? SortBy = null,
    string? SortOrder = null);

public record GetCategoriesResponse(PaginatedResult<CategoryDto> Categories);

public class GetCategoriesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories", async ([AsParameters] GetCategoriesRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetCategoriesQuery>();
            var result = await sender.Send(query);
            var response = result.Adapt<GetCategoriesResponse>();
            return Results.Ok(response);
        })
        .WithName("GetCategories")
        .Produces<GetCategoriesResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Categories")
        .WithDescription("Get all categories");
    }
}       