namespace Catalog.Features.Brands.DeleteBrand;

public record DeleteBrandCommand(Guid BrandId)
    : ICommand<DeleteBrandResult>;

public record DeleteBrandResult(bool IsSuccess);

internal class DeleteBrandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteBrandCommand, DeleteBrandResult>
{
    public async Task<DeleteBrandResult> Handle(
        DeleteBrandCommand command,
        CancellationToken cancellationToken)
    {
        var brand = await unitOfWork.Brands
            .GetByIdAsync(command.BrandId, cancellationToken)
            ?? throw new BrandNotFoundException(command.BrandId);

        unitOfWork.Brands.Delete(brand);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return new DeleteBrandResult(true);
    }
}