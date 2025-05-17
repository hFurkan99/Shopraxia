namespace Catalog.Data.Seed;

public static class InitialData
{
    public static IEnumerable<Product> Products =>
    [
        Product.Create(new CreateProductPayload("Ürün 1", "urun-1", "Ürün 1 Açıklaması", 4.5f, null, null,
        [
            new CreateProductVariantPayload("Ürün-1_Varyant-1", 100, 10,
            [
                new CreateProductAttributePayload("Beden", "M"),
                new CreateProductAttributePayload("Renk", "Mavi"),
            ], 
            [
                new CreateProductImagePayload("https://example.com/urun1image1.jpg", "Ürün 1 Varyant 1 Resmi", 1),
                new CreateProductImagePayload("https://example.com/urun1image2.jpg", "Ürün 1 Varyant 1 Resmi", 2),
            ]),
            new CreateProductVariantPayload("Ürün-1_Varyant-2", 85, 20,
            [
                new CreateProductAttributePayload("Beden", "M"),
                new CreateProductAttributePayload("Renk", "Kırmızı"),
            ],
            [
                new CreateProductImagePayload("https://example.com/urun2image1.jpg", "Ürün 1 Varyant 2 Resmi", 1),
                new CreateProductImagePayload("https://example.com/urun2image2.jpg", "Ürün 1 Varyant 2 Resmi", 2),
            ]),
            new CreateProductVariantPayload("Ürün-1_Varyant-3", 150, 3,
            [
                new CreateProductAttributePayload("Beden", "XL"),
                new CreateProductAttributePayload("Renk", "Kırmızı"),
            ],
            [
                new CreateProductImagePayload("https://example.com/urun3image1.jpg", "Ürün 1 Varyant 3 Resmi", 1),
                new CreateProductImagePayload("https://example.com/urun3image2.jpg", "Ürün 1 Varyant 3 Resmi", 2),
                new CreateProductImagePayload("https://example.com/urun3image3.jpg", "Ürün 1 Varyant 3 Resmi", 3),
            ]),
        ])),
        Product.Create(new CreateProductPayload("Ürün 2", "urun-2", "Ürün 2 Açıklaması", 4.5f, null, null,
        [
            new CreateProductVariantPayload("Ürün-2_Varyant-1", 500, 1500,
            [
                new CreateProductAttributePayload("Beden", "S"),
                new CreateProductAttributePayload("Renk", "Yeşil"),
            ],
            [
                new CreateProductImagePayload("https://example.com/image1.jpg", "Ürün 2 Varyant 1 Resmi", 1),
                new CreateProductImagePayload("https://example.com/image2.jpg", "Ürün 2 Varyant 1 Resmi", 2),
            ]),
        ])),
    ];
}
