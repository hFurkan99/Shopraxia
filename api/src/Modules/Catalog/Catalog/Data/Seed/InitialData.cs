namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products =>
    [
        Product.Create(new ProductDto(Guid.NewGuid(), "Ürün 1", "urun-1", "Ürün 1 Açıklaması", 4.5f, Guid.NewGuid(), "Kategori 1", Guid.NewGuid(), "Marka 1",
        [
            new ProductVariantDto(Guid.NewGuid(), "Ürün-1_Varyant-1", 100, 10,
            [
                new ProductAttributeDto("Beden", "M"),
                new ProductAttributeDto("Renk", "Mavi"),
            ], 
            [
                new ProductImageDto(Guid.NewGuid(), "https://example.com/urun1image1.jpg", "Ürün 1 Varyant 1 Resmi", 1),
                new ProductImageDto(Guid.NewGuid(), "https://example.com/urun1image2.jpg", "Ürün 1 Varyant 1 Resmi", 2),
            ]),
            new ProductVariantDto(Guid.NewGuid(), "Ürün-1_Varyant-2", 85, 20,
            [
                new ProductAttributeDto("Beden", "M"),
                new ProductAttributeDto("Renk", "Kırmızı"),
            ],
            [
                new ProductImageDto(Guid.NewGuid(), "https://example.com/urun2image1.jpg", "Ürün 1 Varyant 2 Resmi", 1),
                new ProductImageDto(Guid.NewGuid(), "https://example.com/urun2image2.jpg", "Ürün 1 Varyant 2 Resmi", 2),
            ]),
            new ProductVariantDto(Guid.NewGuid(), "Ürün-1_Varyant-3", 150, 3,
            [
                new ProductAttributeDto("Beden", "XL"),
                new ProductAttributeDto("Renk", "Kırmızı"),
            ],
            [
                new ProductImageDto(Guid.NewGuid(), "https://example.com/urun3image1.jpg", "Ürün 1 Varyant 3 Resmi", 1),
                new ProductImageDto(Guid.NewGuid(), "https://example.com/urun3image2.jpg", "Ürün 1 Varyant 3 Resmi", 2),
                new ProductImageDto(Guid.NewGuid(), "https://example.com/urun3image3.jpg", "Ürün 1 Varyant 3 Resmi", 3),
            ]),
        ])),
        Product.Create(new ProductDto(Guid.NewGuid(), "Ürün 2", "urun-2", "Ürün 2 Açıklaması", 4.5f, Guid.NewGuid(), "Kategori 1", Guid.NewGuid(), "Marka 2",
        [
            new ProductVariantDto(Guid.NewGuid(), "Ürün-2_Varyant-1", 500, 1500,
            [
                new ProductAttributeDto("Beden", "S"),
                new ProductAttributeDto("Renk", "Yeşil"),
            ],
            [
                new ProductImageDto(Guid.NewGuid(), "https://example.com/image1.jpg", "Ürün 2 Varyant 1 Resmi", 1),
                new ProductImageDto(Guid.NewGuid(), "https://example.com/image2.jpg", "Ürün 2 Varyant 1 Resmi", 2),
            ]),
        ])),
    ];
}
