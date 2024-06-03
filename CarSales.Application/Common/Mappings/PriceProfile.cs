using AutoMapper;
using CarSales.Application.Prices;
using CarSales.Domain.Entities;

namespace CarSales.Application.Common.Mapping;

public class PriceProfile : Profile
{
    public PriceProfile()
    {
        CreateMap<PriceEntity, PriceDTO>()
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Car.Make))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Car.Model));
        CreateMap<PriceDTO, PriceEntity>();
    }
}
