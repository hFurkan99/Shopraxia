namespace Basket.Domain.BasketAggregate.Dtos;

public record ShoppingCartItemDto(
    Guid Id,
    Guid ProductId,
    Guid? VariantId,
    int Quantity,
    decimal UnitPrice,
    string ProductName,
    string ProductVariantSku);
