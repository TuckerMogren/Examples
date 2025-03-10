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
    app.UseSwagger(); // Ensure OpenAPI JSON is available

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
                        theme='dark' 
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

app.MapGet("/greet/{name}", (string name) => $"Hello, {name}!");

app.Run();