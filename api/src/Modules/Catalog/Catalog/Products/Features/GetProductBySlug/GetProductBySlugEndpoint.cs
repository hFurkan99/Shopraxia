namespace Catalog.Products.Features.GetProductBySlug;

//public record GetProductBySlugRequest(string Slug);

public record GetProductBySlugResponse(ProductDto Product);

public class GetProductBySlugEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/slug/{slug}", async (string slug, ISender sender) =>
        {
            var result = await sender.Send(new GetProductBySlugQuery(slug));
            var response = result.Adapt<GetProductBySlugResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductBySlug")
        .Produces<GetProductBySlugResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Slug")
        .WithDescription("Get Product By Slug");
    }
}