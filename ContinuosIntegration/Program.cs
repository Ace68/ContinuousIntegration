using ContinuosIntegration.Modules;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo()
{
    Description = "Web API Service for ContinuousIntegration",
    Title = "ContinuousIntegration Api",
    Version = "v1",
    Contact = new OpenApiContact
    {
        Name = "continuousintegration",
        Url = new Uri("https://continuousintegration.azurewebsites.net")
    }
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

HelloModule.MapHelloEndpoint(app);

// Configure the HTTP request pipeline.
app.UseSwagger(s =>
{
    s.RouteTemplate = "documentation/{documentName}/documentation.json";
    s.SerializeAsV2 = true;
});
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/documentation/v1/documentation.json", "ContinuousIntegration Web API v1");
    s.RoutePrefix = string.Empty;
});

app.Run();