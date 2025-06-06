namespace Catalog.Features.Categories.DeleteCategory;

//public record DeleteCategoryRequest(Guid CategoryId);
public record DeleteCategoryResponse(bool IsSuccess);

public class DeleteCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/categories/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteCategoryCommand(id);
            var result = await sender.Send(command);
            var response = result.Adapt<DeleteCategoryResponse>();
            return Results.Ok(response);
        })
        .WithName("DeleteCategory")
        .Produces<DeleteCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Category")
        .WithDescription("Delete category by ID");
    }
}   