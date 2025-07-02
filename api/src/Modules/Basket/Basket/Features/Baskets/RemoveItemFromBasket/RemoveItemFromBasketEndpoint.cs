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
        app.MapPost("/baskets/remove-item", async (RemoveItemFromBasketRequest request, 
            ISender sender, HttpContext httpContext) =>
        {
            var userId = httpContext.User.GetUserId();

            var command = request.Adapt<RemoveItemFromBasketCommand>() 
            with { UserId = userId };

            var result = await sender.Send(command);
            var response = result.Adapt<RemoveItemFromBasketResponse>();
            return Results.Ok(response);
        })
        .RequireAuthorization()
        .WithName("RemoveItemFromBasket")
        .Produces<RemoveItemFromBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Remove Item from Basket")
        .WithDescription("Remove Item from Basket");
    }
}
