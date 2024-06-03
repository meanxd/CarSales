using AutoMapper;
using CarSales.Application.Cars;
using CarSales.Domain.Entities;

namespace CarSales.Application.Common.Mapping;

public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap<CarEntity, CarDTO>();
        CreateMap<CarDTO, CarEntity>();
    }
}
