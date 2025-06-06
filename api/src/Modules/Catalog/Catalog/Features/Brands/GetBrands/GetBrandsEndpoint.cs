namespace Catalog.Features.Brands.GetBrands;

public record GetBrandsRequest(
    int Page = 1,
    int PageSize = 10,
    string? Search = null,
    string? SortBy = null,       
    string? SortOrder = null);

public record GetBrandsResponse(PaginatedResult<BrandDto> Brands);

public class GetBrandsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/brands", async ([AsParameters] GetBrandsRequest request, ISender sender) =>
        {
            var query = new GetBrandsQuery
            {
                Page = request.Page,
                PageSize = request.PageSize,
                Search = request.Search,
                SortBy = request.SortBy,
                SortOrder = request.SortOrder
            };

            var result = await sender.Send(query);
            var response = new GetBrandsResponse(result.Brands);
            return Results.Ok(response);
        })
        .WithName("GetBrands")
        .Produces<GetBrandsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Brands")
        .WithDescription("Get all brands");
    }
}   