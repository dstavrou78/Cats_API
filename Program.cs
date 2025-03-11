using Cats_API.Interfaces;
using Cats_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient("cats", httpClient =>
{
    string? apiAddress = builder.Configuration.GetValue<string>("cats_api_settings:api_address");
    string? apiKey = builder.Configuration.GetValue<string>("cats_api_settings:api_key");

    if(!string.IsNullOrEmpty(apiAddress))
        httpClient.BaseAddress = new Uri(apiAddress);

    if(!string.IsNullOrEmpty(apiKey))
        httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
});

builder.Services.AddScoped<IExternalAPI, ExternalAPI>();

builder.Services.AddDbContext<CatsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    //options.UseInMemoryDatabase("CatsDB");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Cats API",
        Description = "Demo ASP.NET Core Web API",

    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
