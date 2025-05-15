namespace Catalog.Products.Models;
public class ProductVariant : Entity<Guid>
{
    public string Sku { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public List<ProductAttribute> Attributes { get; set; } = [];
    public List<ProductImage> Images { get; set; } = [];

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

}