namespace Catalog.Features.Products.CreateProduct;

public record CreateProductRequest(
    string Name,
    string Slug,
    string Description,
    float Rating,
    Guid CategoryId,
    Guid BrandId,
    List<CreateProductVariantPayload> Variants);

public record CreateProductResponse(Guid Id);

public class CreateOrderEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateProductResponse>();
            return Results.Created($"/Products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
