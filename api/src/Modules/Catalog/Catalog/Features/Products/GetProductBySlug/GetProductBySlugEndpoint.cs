namespace Catalog.Features.Products.GetProductBySlug;

//public record GetProductBySlugRequest(string Slug);
public record GetProductBySlugResponse(ProductDto Product);

public class GetProductBySlugEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/slug/{slug}", async (string slug, ISender sender) =>
        {
            var query = new GetProductBySlugQuery(slug);
            var result = await sender.Send(query);
            var response = result.Adapt<GetProductBySlugResponse>();
            return Results.Ok(response);
        })
        .WithName("GetProductBySlug")
        .Produces<GetProductBySlugResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Product By Slug")
        .WithDescription("Get Product By Slug");
    }
}