using Catalog.Categories.Features.GetCategoryById;

namespace Catalog.Features.Categories.GetCategoryById;

//public record GetCategoryByIdRequest(Guid CategoryId);
public record GetCategoryByIdResponse(Guid Id, string Name, string Slug, string Description);

public class GetCategoryByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/categories/{id}", async (Guid id, ISender sender) =>
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await sender.Send(query);
            var response = new GetCategoryByIdResponse(result.Id, result.Name, result.Slug, result.Description);
            return Results.Ok(response);
        })
        .WithName("GetCategoryById")
        .Produces<GetCategoryByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Category By Id")
        .WithDescription("Get category details by ID");
    }
}   