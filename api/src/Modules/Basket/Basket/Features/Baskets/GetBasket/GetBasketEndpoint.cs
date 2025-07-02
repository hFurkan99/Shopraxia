namespace Basket.Features.Baskets.GetBasket;

public record GetBasketResponse(Guid ShoppingCartId, Guid UserId, decimal TotalPrice, 
    IReadOnlyList<ShoppingCartItemDto> Items);

public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/baskets", async (HttpContext httpContext,
            ISender sender) =>
        {
            var userId = httpContext.User.GetUserId();
            var query = new GetBasketQuery(userId);
            var result = await sender.Send(query);
            var response = result.Adapt<GetBasketResponse>();
            return Results.Ok(response);
        })
        .RequireAuthorization()
        .WithName("GetBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Basket by User ID")
        .WithDescription("Retrieve the shopping basket for a specific user.");
    }
}
