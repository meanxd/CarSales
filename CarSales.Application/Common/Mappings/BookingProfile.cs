using AutoMapper;
using CarSales.Application.Bookings;
using CarSales.Domain.Entities;

namespace CarSales.Application.Common.Mapping;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<BookingEntity, BookingDTO>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Price));
        CreateMap<BookingDTO, BookingEntity>();
    }
}
