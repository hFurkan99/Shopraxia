namespace Catalog.Categories.Features.CreateCategory;

public record CreateCategoryRequest(CreateCategoryPayload CategoryPayload);
public record CreateCategoryResponse(Guid Id);

public class CreateCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/categories", async (CreateCategoryRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateCategoryCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateCategoryResponse>();
            return Results.Created($"/categories/{response.Id}", response);
        })
        .WithName("CreateCategory")
        .Produces<CreateCategoryResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Category")
        .WithDescription("Create a new category");
    }
}