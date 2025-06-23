namespace Catalog.Contracts.Domain.BrandAggregate.Dtos;

public record BrandDto(
    Guid Id,
    string Name,
    string Slug,
    string? Description);
