namespace Catalog.Contracts.Domain.CategoryAggregate.Dtos;

public record CategoryDto(
    Guid Id,
    string Name,
    string Slug,
    string? Description);