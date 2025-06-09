namespace Catalog.Domain.AttributeAggregate.Dtos;

public record AttributeDto(
    Guid Id, 
    string Name, 
    List<CategoryDto> CategoryAttributes);