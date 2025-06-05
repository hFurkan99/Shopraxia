using Shared.Data.Seed;

namespace Catalog.Data.Seed;

public class CatalogDataSeeder(CatalogDbContext dbContext)
    : IDataSeeder
{
    public async Task SeedAllAsync()
    {
        if (!dbContext.Brands.Any())
        {
            var brands = new[]
            {
                Brand.Create(new CreateBrandPayload("Nike", "nike", "Dünyaca ünlü spor giyim ve ayakkabı markası.")),
                Brand.Create(new CreateBrandPayload("Adidas", "adidas", "Alman spor giyim ve ayakkabı markası.")),
                Brand.Create(new CreateBrandPayload("Apple", "apple", "Teknoloji ve elektronik ürünler markası.")),
                Brand.Create(new CreateBrandPayload("Samsung", "samsung", "Güney Koreli elektronik ve teknoloji markası.")),
                Brand.Create(new CreateBrandPayload("Puma", "puma", "Spor giyim ve ayakkabı markası."))
            };

            await dbContext.Brands.AddRangeAsync(brands);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Categories.Any())
        {
            var categories = new[]
            {
                Category.Create(new CreateCategoryPayload("Spor Ayakkabı", "spor-ayakkabi", "Koşu, basketbol ve günlük spor ayakkabılar.")),
                Category.Create(new CreateCategoryPayload("Akıllı Telefon", "akilli-telefon", "Güncel akıllı telefon modelleri.")),
                Category.Create(new CreateCategoryPayload("Tişört", "tisort", "Farklı renk ve modellerde tişörtler.")),
                Category.Create(new CreateCategoryPayload("Dizüstü Bilgisayar", "dizustu-bilgisayar", "Taşınabilir bilgisayarlar.")),
                Category.Create(new CreateCategoryPayload("Aksesuar", "aksesuar", "Telefon, bilgisayar ve giyim aksesuarları."))
            };

            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.Products.Any())
        {
            var nike = await dbContext.Brands.FirstAsync(b => b.Name == "Nike");
            var adidas = await dbContext.Brands.FirstAsync(b => b.Name == "Adidas");
            var apple = await dbContext.Brands.FirstAsync(b => b.Name == "Apple");
            var samsung = await dbContext.Brands.FirstAsync(b => b.Name == "Samsung");
            var puma = await dbContext.Brands.FirstAsync(b => b.Name == "Puma");

            var sporAyakkabi = await dbContext.Categories.FirstAsync(c => c.Name == "Spor Ayakkabı");
            var akilliTelefon = await dbContext.Categories.FirstAsync(c => c.Name == "Akıllı Telefon");
            var tisort = await dbContext.Categories.FirstAsync(c => c.Name == "Tişört");

            var products = new[]
            {
                Product.Create(new CreateProductPayload(
                    "Nike Air Max 270",
                    "nike-air-max-270",
                    "Nike'ın popüler koşu ve günlük ayakkabısı.",
                    4.8f,
                    sporAyakkabi.Id,
                    nike.Id,
                    [
                        new CreateProductVariantPayload(
                            "AM270-BEYAZ-42", 2999, 15,
                            [
                                new CreateProductAttributePayload("Renk", "Beyaz"),
                                new CreateProductAttributePayload("Numara", "42"),
                            ],
                            [
                                new CreateProductImagePayload("https://static.nike.com/a/images/t_PDP_864_v1/f_auto,q_auto:eco/air-max-270.jpg", "Nike Air Max 270 Beyaz 42", 1)
                            ]
                        ),
                        new CreateProductVariantPayload(
                            "AM270-SIYAH-43", 2999, 10,
                            [
                                new CreateProductAttributePayload("Renk", "Siyah"),
                                new CreateProductAttributePayload("Numara", "43"),
                            ],
                            [
                                new CreateProductImagePayload("https://static.nike.com/a/images/t_PDP_864_v1/f_auto,q_auto:eco/air-max-270-black.jpg", "Nike Air Max 270 Siyah 43", 1)
                            ]
                        )
                    ]
                )),
                Product.Create(new CreateProductPayload(
                    "Adidas Ultraboost 22",
                    "adidas-ultraboost-22",
                    "Adidas'ın en konforlu koşu ayakkabısı.",
                    4.7f,
                    sporAyakkabi.Id,
                    adidas.Id,
                    [
                        new CreateProductVariantPayload(
                            "UB22-GRI-44", 3199, 8,
                            [
                                new CreateProductAttributePayload("Renk", "Gri"),
                                new CreateProductAttributePayload("Numara", "44"),
                            ],
                            [
                                new CreateProductImagePayload("https://assets.adidas.com/images/ultraboost-22.jpg", "Adidas Ultraboost 22 Gri 44", 1)
                            ]
                        ),
                        new CreateProductVariantPayload(
                            "UB22-MAVI-42", 3199, 12,
                            [
                                new CreateProductAttributePayload("Renk", "Mavi"),
                                new CreateProductAttributePayload("Numara", "42"),
                            ],
                            [
                                new CreateProductImagePayload("https://assets.adidas.com/images/ultraboost-22-blue.jpg", "Adidas Ultraboost 22 Mavi 42", 1)
                            ]
                        )
                    ]
                )),
                Product.Create(new CreateProductPayload(
                    "Apple iPhone 15 Pro",
                    "apple-iphone-15-pro",
                    "Apple'ın en yeni akıllı telefonu.",
                    4.9f,
                    akilliTelefon.Id,
                    apple.Id,
                    [
                        new CreateProductVariantPayload(
                            "IPH15PRO-128GB-GRİ", 69999, 20,
                            [
                                new CreateProductAttributePayload("Renk", "Titanyum Gri"),
                                new CreateProductAttributePayload("Depolama", "128GB"),
                            ],
                            [
                                new CreateProductImagePayload("https://store.storeimages.cdn-apple.com/iphone-15-pro.jpg", "iPhone 15 Pro 128GB Gri", 1)
                            ]
                        ),
                        new CreateProductVariantPayload(
                            "IPH15PRO-256GB-MAVİ", 74999, 10,
                            [
                                new CreateProductAttributePayload("Renk", "Mavi"),
                                new CreateProductAttributePayload("Depolama", "256GB"),
                            ],
                            [
                                new CreateProductImagePayload("https://store.storeimages.cdn-apple.com/iphone-15-pro-blue.jpg", "iPhone 15 Pro 256GB Mavi", 1)
                            ]
                        )
                    ]
                )),
                Product.Create(new CreateProductPayload(
                    "Samsung Galaxy S24 Ultra",
                    "samsung-galaxy-s24-ultra",
                    "Samsung'un amiral gemisi akıllı telefonu.",
                    4.8f,
                    akilliTelefon.Id,
                    samsung.Id,
                    [
                        new CreateProductVariantPayload(
                            "S24U-256GB-SIYAH", 64999, 18,
                            [
                                new CreateProductAttributePayload("Renk", "Siyah"),
                                new CreateProductAttributePayload("Depolama", "256GB"),
                            ],
                            [
                                new CreateProductImagePayload("https://images.samsung.com/galaxy-s24-ultra.jpg", "Galaxy S24 Ultra 256GB Siyah", 1)
                            ]
                        ),
                        new CreateProductVariantPayload(
                            "S24U-512GB-GUMUS", 69999, 7,
                            [
                                new CreateProductAttributePayload("Renk", "Gümüş"),
                                new CreateProductAttributePayload("Depolama", "512GB"),
                            ],
                            [
                                new CreateProductImagePayload("https://images.samsung.com/galaxy-s24-ultra-silver.jpg", "Galaxy S24 Ultra 512GB Gümüş", 1)
                            ]
                        )
                    ]
                )),
                Product.Create(new CreateProductPayload(
                    "Puma Essentials Logo Tişört",
                    "puma-essentials-logo-tisort",
                    "Puma'nın günlük kullanıma uygun tişörtü.",
                    4.6f,
                    tisort.Id,
                    puma.Id,
                    [
                        new CreateProductVariantPayload(
                            "PUMA-TSHIRT-BEYAZ-M", 499, 30,
                            [
                                new CreateProductAttributePayload("Renk", "Beyaz"),
                                new CreateProductAttributePayload("Beden", "M"),
                            ],
                            [
                                new CreateProductImagePayload("https://images.puma.com/essentials-logo-tshirt-white.jpg", "Puma Essentials Logo Tişört Beyaz M", 1)
                            ]
                        ),
                        new CreateProductVariantPayload(
                            "PUMA-TSHIRT-SIYAH-L", 499, 25,
                            [
                                new CreateProductAttributePayload("Renk", "Siyah"),
                                new CreateProductAttributePayload("Beden", "L"),
                            ],
                            [
                                new CreateProductImagePayload("https://images.puma.com/essentials-logo-tshirt-black.jpg", "Puma Essentials Logo Tişört Siyah L", 1)
                            ]
                        )
                    ]
                ))
            };

            await dbContext.Products.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();
        }
    }
}