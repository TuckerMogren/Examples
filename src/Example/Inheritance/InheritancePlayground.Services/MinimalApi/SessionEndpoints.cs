using InheritancePlayground.Application.Adapters.Household.People;
using InheritancePlayground.Application.Adapters.Household.Pets;
using Newtonsoft.Json;

namespace InheritancePlayground.Services.MinimalApi
{
    public static class SessionEndpoints
    {
        public static void MapSessionEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/adult", () =>
            {
                var person = new Adult("Tucker", 29);
                return Results.Text(JsonConvert.SerializeObject(person), "application/json");
            });

            app.MapGet("/child", () =>
            {
                var person = new Person("Jimmy", 3);
                return Results.Text(JsonConvert.SerializeObject(person), "application/json");
            });

            app.MapGet("/dog", () =>
            {
                var person = new Dog("Dougie", 4, "Tennis Ball");
                return Results.Text(JsonConvert.SerializeObject(person), "application/json");
            });
        }
    }
}