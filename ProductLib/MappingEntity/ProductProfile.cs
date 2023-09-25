using AutoMapper;
using ProductLib.Models;

namespace ProductLib.MappingEntity;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductResponse>();
        CreateMap<ProductCreateReq, Product>()
            .ForMember(e => e.Id, opt => opt.MapFrom(e => Guid.NewGuid().ToString()));
        // CreateMap<ProductUpdateReq, Product>()
        //     .ForMember(e => e.Id, opt => opt.Ignore())
        //     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category ?? default));
    }

}