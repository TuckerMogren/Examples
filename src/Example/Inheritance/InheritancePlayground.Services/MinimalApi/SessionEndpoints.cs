using AutoMapper;
using InheritancePlayground.Application.Adapters.Household.House;
using InheritancePlayground.Application.Adapters.Household.People;
using InheritancePlayground.Application.Adapters.Household.Pets;
using InheritancePlayground.Domain.SessionModels;
using Newtonsoft.Json;

namespace InheritancePlayground.Services.MinimalApi
{
    public static class SessionEndpoints
    {
        public static void MapSessionEndpoints(this IEndpointRouteBuilder app)
        {
            _ = app.MapGet("/test", (IMapper mapper) =>
            {
                var home = new Home();
                var dog = new Dog("Dougie", 4, "Tennis Ball");
                var mom = new Adult("Tanner", 30);
                var dad = new Adult("Joan", 34);
                var son = new Child("Jaxon", 5, [mom, dad]);

                dad.AddSpouse(mom);

                var household = new HouseholdDto();
                household.AddAdult(mapper.Map<AdultDto>(mom));
                household.AddAdult(mapper.Map<AdultDto>(dad));
                household.AddChild(mapper.Map<ChildDto>(son));
                household.AddPet(mapper.Map<PetDto>(dog));
                household.AddHome(mapper.Map<HomeDto>(home));

                return Results.Text(JsonConvert.SerializeObject(household), "application/json");
            });
        }
    }
}