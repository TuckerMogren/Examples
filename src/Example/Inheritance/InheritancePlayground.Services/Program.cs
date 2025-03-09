var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets(typeof(Program).Assembly)
    .AddEnvironmentVariables();

var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Documentation",
        Version = "v1"
    });
});

var app = builder.Build();

// Redirect root to ReDoc
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/docs");
        return;
    }
    await next();
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger(); // Ensure OpenAPI JSON is generated
    app.UseReDoc(c =>
    {
        c.RoutePrefix = "docs"; // API documentation available at `/docs`
        c.DocumentTitle = "API Documentation";
        c.SpecUrl("/swagger/v1/swagger.json"); // Ensure Swagger JSON is loaded
    });
}

app.UseHttpsRedirection();

app.MapGet("/greet/{name}", (string name) => $"Hello, {name}!");

app.Run();