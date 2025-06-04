namespace Catalog.Brands.Features.GetBrands;

public record GetBrandsRequest(GetBrandsPayload Payload);
public record GetBrandsResponse(PaginatedResult<BrandDto> Brands);

public class GetBrandsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/brands", async ([AsParameters] GetBrandsPayload payload, ISender sender) =>
        {
            var query = new GetBrandsQuery(payload);
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