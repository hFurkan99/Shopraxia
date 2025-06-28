namespace Basket.Features.Baskets.GetBasket;

//public record GetBasketRequest(Guid UserId);

public record GetBasketResponse(Guid ShoppingCartId, Guid UserId, decimal TotalPrice, 
    IReadOnlyList<ShoppingCartItemDto> Items);

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baskets/{userId:guid}", async (Guid userId, ISender sender) =>
        {
            var query = new GetBasketQuery(userId);
            var result = await sender.Send(query);
            var response = result.Adapt<GetBasketResponse>();
            return Results.Ok(response);
        })
        .WithName("GetBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Basket by User ID")
        .WithDescription("Retrieve the shopping basket for a specific user.");
    }
}
