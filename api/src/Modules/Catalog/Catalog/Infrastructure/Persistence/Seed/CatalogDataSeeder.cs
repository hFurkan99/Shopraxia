using Shared.Data.Seed;

namespace Catalog.Infrastructure.Persistence.Seed;

public class CatalogDataSeeder(CatalogDbContext dbContext)
    : IDataSeeder
{
    public async Task SeedAllAsync()
    {
        // Brand Seed
        if (!dbContext.Brands.Any())
        {
            var brands = new[]
            {
                Brand.Create("Nike", "nike", "Dünyaca ünlü spor giyim ve ayakkabı markası."),
                Brand.Create("Adidas", "adidas", "Alman spor giyim ve ayakkabı markası."),
                Brand.Create("Apple", "apple", "Teknoloji ve elektronik ürünler markası."),
                Brand.Create("Samsung", "samsung", "Güney Koreli elektronik ve teknoloji markası."),
                Brand.Create("Puma", "puma", "Spor giyim ve ayakkabı markası.")
            };

            await dbContext.Brands.AddRangeAsync(brands);
            await dbContext.SaveChangesAsync();
        }

        // Category Seed
        if (!dbContext.Categories.Any())
        {
            var categories = new[]
            {
                Category.Create("Spor Ayakkabı", "spor-ayakkabi", "Koşu, basketbol ve günlük spor ayakkabılar."),
                Category.Create("Akıllı Telefon", "akilli-telefon", "Güncel akıllı telefon modelleri."),
                Category.Create("Tişört", "tisort", "Farklı renk ve modellerde tişörtler."),
                Category.Create("Dizüstü Bilgisayar", "dizustu-bilgisayar", "Taşınabilir bilgisayarlar."),
                Category.Create("Aksesuar", "aksesuar", "Telefon, bilgisayar ve giyim aksesuarları.")
            };

            await dbContext.Categories.AddRangeAsync(categories);
            await dbContext.SaveChangesAsync();
        }

        // Attribute Seed
        if (!dbContext.Attributes.Any())
        {
            var categories = await dbContext.Categories.ToListAsync();
            var sporAyakkabi = categories.First(c => c.Name == "Spor Ayakkabı");
            var tisort = categories.First(c => c.Name == "Tişört");
            var akilliTelefon = categories.First(c => c.Name == "Akıllı Telefon");

            var attributes = new[]
            {
                Attribute.Create("Renk", sporAyakkabi.Id),
                Attribute.Create("Numara", sporAyakkabi.Id),
                Attribute.Create("Beden", tisort.Id),
                Attribute.Create("Depolama", akilliTelefon.Id),
            };

            await dbContext.Attributes.AddRangeAsync(attributes);
            await dbContext.SaveChangesAsync();
        }

        // CategoryAttribute ilişkisi (örnek eşleşmeler)
        //if (!dbContext.Set<CategoryAttribute>().Any())
        //{

        //    // Spor Ayakkabı: Renk, Numara
        //    var renk = attributes.First(a => a.Name == "Renk");
        //    var numara = attributes.First(a => a.Name == "Numara");
        //    categoryAttributes.Add(CategoryAttribute.Create(sporAyakkabi.Id, renk.Id));
        //    categoryAttributes.Add(CategoryAttribute.Create(sporAyakkabi.Id, numara.Id));

        //    // Tişört: Renk, Beden
        //    var beden = attributes.First(a => a.Name == "Beden");
        //    categoryAttributes.Add(CategoryAttribute.Create(tisort.Id, renk.Id));
        //    categoryAttributes.Add(CategoryAttribute.Create(tisort.Id, beden.Id));

        //    // Akıllı Telefon: Renk, Depolama
        //    var depolama = attributes.First(a => a.Name == "Depolama");
        //    categoryAttributes.Add(CategoryAttribute.Create(akilliTelefon.Id, renk.Id));
        //    categoryAttributes.Add(CategoryAttribute.Create(akilliTelefon.Id, depolama.Id));

        //    await dbContext.Set<CategoryAttribute>().AddRangeAsync(categoryAttributes);
        //    await dbContext.SaveChangesAsync();
        //}

        // Product & Variant Seed
        if (!dbContext.Products.Any())
        {
            var brands = await dbContext.Brands.ToListAsync();
            var categories = await dbContext.Categories.ToListAsync();
            var attributes = await dbContext.Attributes.ToListAsync();

            var nike = brands.First(b => b.Name == "Nike");
            var adidas = brands.First(b => b.Name == "Adidas");
            var apple = brands.First(b => b.Name == "Apple");
            var samsung = brands.First(b => b.Name == "Samsung");
            var puma = brands.First(b => b.Name == "Puma");

            var sporAyakkabi = categories.First(c => c.Name == "Spor Ayakkabı");
            var akilliTelefon = categories.First(c => c.Name == "Akıllı Telefon");
            var tisort = categories.First(c => c.Name == "Tişört");

            var renk = attributes.First(a => a.Name == "Renk");
            var numara = attributes.First(a => a.Name == "Numara");
            var beden = attributes.First(a => a.Name == "Beden");
            var depolama = attributes.First(a => a.Name == "Depolama");

            var products = new[]
            {
                Product.Create(
                    "Nike Air Max 270",
                    "nike-air-max-270",
                    "Nike'ın popüler koşu ve günlük ayakkabısı.",
                    4.8f,
                    sporAyakkabi.Id,
                    nike.Id,
                    new List<Variant>
                    {
                        Variant.Create(
                            "AM270-BEYAZ-42", 2999, 15,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Beyaz"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = numara.Id,
                                    Value = "42"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://static.nike.com/a/images/t_PDP_864_v1/f_auto,q_auto:eco/air-max-270.jpg", "Nike Air Max 270 Beyaz 42", 1)
                            },
                            Guid.Empty
                        ),
                        Variant.Create(
                            "AM270-SIYAH-43", 2999, 10,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Siyah"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = numara.Id,
                                    Value = "43"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://static.nike.com/a/images/t_PDP_864_v1/f_auto,q_auto:eco/air-max-270-black.jpg", "Nike Air Max 270 Siyah 43", 1)
                            },
                            Guid.Empty
                        )
                    }
                ),
                Product.Create(
                    "Adidas Ultraboost 22",
                    "adidas-ultraboost-22",
                    "Adidas'ın en konforlu koşu ayakkabısı.",
                    4.7f,
                    sporAyakkabi.Id,
                    adidas.Id,
                    new List<Variant>
                    {
                        Variant.Create(
                            "UB22-GRI-44", 3199, 8,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Gri"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = numara.Id,
                                    Value = "44"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://assets.adidas.com/images/ultraboost-22.jpg", "Adidas Ultraboost 22 Gri 44", 1)
                            },
                            Guid.Empty
                        ),
                        Variant.Create(
                            "UB22-MAVI-42", 3199, 12,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Mavi"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = numara.Id,
                                    Value = "42"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://assets.adidas.com/images/ultraboost-22-blue.jpg", "Adidas Ultraboost 22 Mavi 42", 1)
                            },
                            Guid.Empty
                        )
                    }
                ),
                Product.Create(
                    "Apple iPhone 15 Pro",
                    "apple-iphone-15-pro",
                    "Apple'ın en yeni akıllı telefonu.",
                    4.9f,
                    akilliTelefon.Id,
                    apple.Id,
                    new List<Variant>
                    {
                        Variant.Create(
                            "IPH15PRO-128GB-GRİ", 69999, 20,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Titanyum Gri"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = depolama.Id,
                                    Value = "128GB"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://store.storeimages.cdn-apple.com/iphone-15-pro.jpg", "iPhone 15 Pro 128GB Gri", 1)
                            },
                            Guid.Empty
                        ),
                        Variant.Create(
                            "IPH15PRO-256GB-MAVİ", 74999, 10,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Mavi"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = depolama.Id,
                                    Value = "256GB"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://store.storeimages.cdn-apple.com/iphone-15-pro-blue.jpg", "iPhone 15 Pro 256GB Mavi", 1)
                            },
                            Guid.Empty
                        )
                    }
                ),
                Product.Create(
                    "Samsung Galaxy S24 Ultra",
                    "samsung-galaxy-s24-ultra",
                    "Samsung'un amiral gemisi akıllı telefonu.",
                    4.8f,
                    akilliTelefon.Id,
                    samsung.Id,
                    new List<Variant>
                    {
                        Variant.Create(
                            "S24U-256GB-SIYAH", 64999, 18,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Siyah"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = depolama.Id,
                                    Value = "256GB"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://images.samsung.com/galaxy-s24-ultra.jpg", "Galaxy S24 Ultra 256GB Siyah", 1)
                            },
                            Guid.Empty
                        ),
                        Variant.Create(
                            "S24U-512GB-GUMUS", 69999, 7,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Gümüş"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = depolama.Id,
                                    Value = "512GB"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://images.samsung.com/galaxy-s24-ultra-silver.jpg", "Galaxy S24 Ultra 512GB Gümüş", 1)
                            },
                            Guid.Empty
                        )
                    }
                ),
                Product.Create(
                    "Puma Essentials Logo Tişört",
                    "puma-essentials-logo-tisort",
                    "Puma'nın günlük kullanıma uygun tişörtü.",
                    4.6f,
                    tisort.Id,
                    puma.Id,
                    new List<Variant>
                    {
                        Variant.Create(
                            "PUMA-TSHIRT-BEYAZ-M", 499, 30,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Beyaz"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = beden.Id,
                                    Value = "M"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://images.puma.com/essentials-logo-tshirt-white.jpg", "Puma Essentials Logo Tişört Beyaz M", 1)
                            },
                            Guid.Empty
                        ),
                        Variant.Create(
                            "PUMA-TSHIRT-SIYAH-L", 499, 25,
                            new List<VariantAttribute>
                            {
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = renk.Id,
                                    Value = "Siyah"
                                },
                                new VariantAttribute {
                                    Id = Guid.Empty,
                                    AttributeId = beden.Id,
                                    Value = "L"
                                },
                            },
                            new List<Image>
                            {
                                Image.Create("https://images.puma.com/essentials-logo-tshirt-black.jpg", "Puma Essentials Logo Tişört Siyah L", 1)
                            },
                            Guid.Empty
                        )
                    }
                )
            };

            await dbContext.Products.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();
        }

        // VariantAttribute tablosu için ayrıca bir şey yapmaya gerek yok:
        // Çünkü Variant.Create ile VariantAttribute nesneleri zaten Variant'lara ekleniyor ve EF Core ile birlikte VariantAttribute tablosu otomatik olarak doldurulacaktır.
    }
}