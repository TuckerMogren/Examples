var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseReDoc(c =>
    {
        c.RoutePrefix = "docs"; // Access API docs at `/docs`
        c.DocumentTitle = "API Documentation";
    });
}

app.UseHttpsRedirection();

app.Run();




