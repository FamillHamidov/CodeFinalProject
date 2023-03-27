using AutoMapper;
using Travel.Services.Catalog.Dtos;
using Travel.Services.Catalog.Models;

namespace Travel.Services.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Tour, TourDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<Tour, TourCreateDto>().ReverseMap();
            CreateMap<Tour, TourUpdateDto>().ReverseMap();
        }
    }
}
