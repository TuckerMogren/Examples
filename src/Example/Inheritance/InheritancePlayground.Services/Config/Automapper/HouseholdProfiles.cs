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

            CreateMap<Adult, AdultDto>();

            CreateMap<Child, ChildDto>();

            CreateMap<Dog, DogDto>();

            CreateMap<Home, HomeDto>();

            CreateMap<Household, HouseholdDto>();

            CreateMap<Pet, PetDto>();

        }
    }
}