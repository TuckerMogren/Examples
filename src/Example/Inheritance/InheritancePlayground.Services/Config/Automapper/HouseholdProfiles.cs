using AutoMapper;
using InheritancePlayground.Application.Adapters.Household;
using InheritancePlayground.Application.Adapters.Household.House;
using InheritancePlayground.Application.Adapters.Household.People;
using InheritancePlayground.Application.Adapters.Household.Pets;
using InheritancePlayground.Domain.SessionModels;

namespace InheritancePlayground.Services.Config.Automapper
{
    public class HouseholdProfile : Profile
    {
        public HouseholdProfile()
        {
            CreateMap<Household, HouseholdDto>()
            .ForMember(dest => dest.Adults, opt => opt.Ignore( ) )
            .ForMember(dest => dest.Pets, opt => opt.Ignore( ) )
            .ForMember(dest => dest.Children, opt => opt.Ignore( ) )
            .ForMember(dest => dest.Homes, opt => opt.Ignore( ) );

            CreateMap<Adult, AdultDto>()
            .ForMember(dest => dest.HasChildren, opt => opt.MapFrom(src => src.Children.Count > 0))
            .ForMember(dest => dest.HasSpouse, opt => opt.MapFrom(src => src.HasSpouse))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation));

            CreateMap<Child, ChildDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            ;

            CreateMap<Dog, DogDto>()
            .ForMember(dest => dest.FavoriteToy, opt => opt.MapFrom(src => src.FavoriteToy));

            CreateMap<Home, HomeDto>();

            CreateMap<Pet, PetDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}