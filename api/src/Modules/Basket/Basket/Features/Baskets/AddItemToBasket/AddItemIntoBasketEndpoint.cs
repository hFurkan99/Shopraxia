namespace Basket.Features.Baskets.AddItemToBasket;

public record AddItemIntoBasketRequest(
    Guid UserId,
    Guid ProductId,
    Guid? ProductVariantId,
    int Quantity);

public record AddItemIntoBasketResponse(Guid Id);

public class AddItemIntoBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/baskets/add-item", async (AddItemIntoBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<AddItemIntoBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<AddItemIntoBasketResponse>();
            return Results.Created($"/baskets/{response.Id}", response);
        })
        .WithName("AddItemToBasket")
        .Produces<AddItemIntoBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Add Item to Basket")
        .WithDescription("Add Item to Basket");
    }
}
