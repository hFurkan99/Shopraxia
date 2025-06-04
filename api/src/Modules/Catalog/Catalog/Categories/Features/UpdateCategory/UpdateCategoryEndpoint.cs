namespace Catalog.Categories.Features.UpdateCategory;

public record UpdateCategoryRequest(UpdateCategoryPayload CategoryPayload);
public record UpdateCategoryResponse(bool IsSuccess);

public class UpdateCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/categories", async (UpdateCategoryRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateCategoryCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<UpdateCategoryResponse>();
            return Results.Ok(response);
        })
        .WithName("UpdateCategory")
        .Produces<UpdateCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Category")
        .WithDescription("Update category by ID");
    }
}