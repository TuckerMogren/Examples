using InheritancePlayground.Application.Adapters.Household.People;
using InheritancePlayground.Services.Config;
using InheritancePlayground.Services.MinimalApi;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    });

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddUserSecrets(typeof(Program).Assembly)
    .AddEnvironmentVariables();

var configuration = builder.Configuration;

// Configure AutoMapper
var mapperConfig = AutomapperConfig.ConfigureAutomapper();
var mapper = mapperConfig.CreateMapper();

builder.Services.AddSingleton(mapper);

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
app.UseHttpsRedirection();
app.UseCors(); 



// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger(); // Ensure OpenAPI JSON is available


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


    // Serve Rapidoc UI at `/docs`
    app.Use(async (context, next) =>
    {
        if (context.Request.Path == "/docs")
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync(@"
                <!DOCTYPE html>
                <html>
                <head><title>API Documentation</title></head>
                <body>
                    <rapi-doc 
                        spec-url='/swagger/v1/swagger.json' 
                        theme='light' 
                        render-style='read'>
                    </rapi-doc>
                    <script src='https://unpkg.com/rapidoc/dist/rapidoc-min.js'></script>
                </body>
                </html>");
            return;
        }
        await next();
    });



}

app.UseHttpsRedirection();

app.MapSessionEndpoints();

app.Run();