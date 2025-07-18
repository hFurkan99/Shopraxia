namespace Catalog.Features.Categories.GetCategoryBySlug;

//public record GetCategoryBySlugRequest(string Slug);
public record GetCategoryBySlugResponse(
    Guid Id, 
    string Name, 
    string Slug, 
    string? Description);

public class GetCategoryBySlugEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories/slug/{slug}", async (string slug, ISender sender) =>
        {
            var query = new GetCategoryBySlugQuery(slug);
            var result = await sender.Send(query);
            var response = result.Adapt<GetCategoryBySlugResponse>();
            return Results.Ok(response);
        })
        .WithName("GetCategoryBySlug")
        .Produces<GetCategoryBySlugResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Category By Slug")
        .WithDescription("Get category details by slug");
    }
}   