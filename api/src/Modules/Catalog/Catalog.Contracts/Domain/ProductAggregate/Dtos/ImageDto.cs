namespace Catalog.Contracts.Domain.ProductAggregate.Dtos;

public record ImageDto(
    Guid Id,
    string Url,
    string AltText,
    int SortOrder);