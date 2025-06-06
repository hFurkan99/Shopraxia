using Catalog.Brands.Features.GetBrandBySlug;

namespace Catalog.Features.Brands.GetBrandBySlug;

//public record GetBrandBySlugRequest(string Slug);
public record GetBrandBySlugResponse(Guid Id, string Name, string Slug, string Description);

public class GetBrandBySlugEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/brands/slug/{slug}", async (string slug, ISender sender) =>
        {
            var query = new GetBrandBySlugQuery(slug);
            var result = await sender.Send(query);
            var response = new GetBrandBySlugResponse(result.Id, result.Name, result.Slug, result.Description);
            return Results.Ok(response);
        })
        .WithName("GetBrandBySlug")
        .Produces<GetBrandBySlugResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Brand By Slug")
        .WithDescription("Get brand details by slug");
    }
}   