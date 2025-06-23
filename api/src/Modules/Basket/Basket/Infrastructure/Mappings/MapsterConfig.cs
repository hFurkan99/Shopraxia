namespace Basket.Infrastructure.Mappings;

public class MapsterConfig
{
    public static void RegisterMappings()
    {
        //TypeAdapterConfig<Product, ProductDto>.NewConfig()
        //    .Map(dest => dest.Variants, src => src.Variants
        //        .OrderBy(v => v.Price)
        //        .Select(v => v.Adapt<VariantDto>())
        //        .ToList());

        //TypeAdapterConfig<Variant, VariantDto>.NewConfig()
        //    .Map(dest => dest.Attributes, src => src.VariantAttributes)
        //    .Map(dest => dest.Images, src => src.Images);

        //TypeAdapterConfig<Attribute, AttributeDto>.NewConfig();
        //TypeAdapterConfig<Image, ImageDto>.NewConfig();

        //TypeAdapterConfig<Category, CategoryDto>.NewConfig();
        //TypeAdapterConfig<Brand, BrandDto>.NewConfig();
    }
}
