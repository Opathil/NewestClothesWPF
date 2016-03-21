namespace Clothes.Models.ModelsDTO
{
    using AutoMapper;

    public static class MappingConfigurations
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Category, CategoryDTO>().ReverseMap();

            Mapper.CreateMap<ClothesColor, ClothesColorDTO>().ReverseMap();

            Mapper.CreateMap<Supplier, SupplierDTO>().ReverseMap();

            Mapper.CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ClothesColorName,
                           opts => opts.MapFrom(src => src.Color.Name))
                .ReverseMap();

            Mapper.CreateMap<Sale, SaleDTO>().ReverseMap();

            Mapper.CreateMap<DailyReport, DailyReportDTO>().ReverseMap();
        }
        
    }
}
