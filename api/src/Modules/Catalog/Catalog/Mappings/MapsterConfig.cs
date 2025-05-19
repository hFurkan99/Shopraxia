namespace Catalog.Mappings;

public static class MapsterConfig
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Product, ProductDto>.NewConfig()
            .Map(dest => dest.Variants, src => src.Variants
                .OrderBy(v => v.Price)
                .Select(v => v.Adapt<ProductVariantDto>())
                .ToList());

        TypeAdapterConfig<ProductVariant, ProductVariantDto>.NewConfig()
            .Map(dest => dest.Attributes, src => src.Attributes)
            .Map(dest => dest.Images, src => src.Images);

        TypeAdapterConfig<Attribute, ProductAttributeDto>.NewConfig();
        TypeAdapterConfig<ProductImage, ProductImageDto>.NewConfig();
    }
}