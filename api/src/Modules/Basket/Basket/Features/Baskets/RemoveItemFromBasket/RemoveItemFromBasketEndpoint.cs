namespace Basket.Features.Baskets.RemoveItemFromBasket;

public record RemoveItemFromBasketRequest(
    Guid UserId,
    Guid ProductId,
    Guid? ProductVariantId,
    int Quantity);

public record RemoveItemFromBasketResponse(Guid Id);

public class RemoveItemFromBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/baskets/remove-item", async (RemoveItemFromBasketRequest request, ISender sender) =>
        {
            var command = request.Adapt<RemoveItemFromBasketCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<RemoveItemFromBasketResponse>();
            return Results.Ok(response);
        })
        .WithName("RemoveItemFromBasket")
        .Produces<RemoveItemFromBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Remove Item from Basket")
        .WithDescription("Remove Item from Basket");
    }
}
