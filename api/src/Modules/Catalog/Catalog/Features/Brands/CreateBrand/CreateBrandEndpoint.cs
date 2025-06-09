namespace Catalog.Features.Brands.CreateBrand;

public record CreateBrandRequest(
    string Name,
    string Slug,
    string? Description);

public record CreateBrandResponse(Guid Id);

public class CreateBrandEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/brands", async (CreateBrandRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateBrandCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateBrandResponse>();
            return Results.Created($"/Brands/{response.Id}", response);
        })
        .WithName("CreateBrand")
        .Produces<CreateBrandResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Brand")
        .WithDescription("Create Brand");
    }
}