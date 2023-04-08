using ShopAPI.Configurations;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .SetBasePath(Directory.GetCurrentDirectory())
    //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();




var applicationSettings = config.AsApplicationSettings();
builder.Services.ConfigureApplicationSettings(applicationSettings);
// Add services to the container.
builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureVersioning();
builder.Services.ConfigureData(config);
builder.Services.ConfigureSwagger();

builder.Services.ConfigureRepositories();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureMediatR();
builder.Services.AddOktaAuthentication(applicationSettings);

builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});
builder.Services.AddLogging();

builder.Services.ConfigureLogging();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

