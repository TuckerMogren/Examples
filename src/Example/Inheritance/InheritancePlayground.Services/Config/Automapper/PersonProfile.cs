using AutoMapper;
using InheritancePlayground.Application.Adapters.Household.People;
using InheritancePlayground.Domain.SessionModels;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDto>();
    }
}