namespace Basket.Features.Baskets.AddItemToBasket;

public record AddItemIntoBasketRequest(
    Guid ProductId,
    Guid? ProductVariantId,
    int Quantity);

public record AddItemIntoBasketResponse(Guid Id);

public class AddItemIntoBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/baskets/add-item", async (AddItemIntoBasketRequest request, 
            ISender sender, HttpContext httpContext) =>
        {
            var userId = httpContext.User.GetUserId();
            
            var command = request.Adapt<AddItemIntoBasketCommand>() 
            with { UserId = userId };

            var result = await sender.Send(command);
            var response = result.Adapt<AddItemIntoBasketResponse>();
            return Results.Created($"/baskets/{response.Id}", response);
        })
        .RequireAuthorization()
        .WithName("AddItemToBasket")
        .Produces<AddItemIntoBasketResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Add Item to Basket")
        .WithDescription("Add Item to Basket");
    }
}
