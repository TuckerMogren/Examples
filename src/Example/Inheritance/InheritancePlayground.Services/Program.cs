var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets(typeof(Program).Assembly)
    .AddEnvironmentVariables();

var configuration = builder.Configuration;

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




