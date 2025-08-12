using ContactService.Application.DependencyInjection;
using ContactService.Application.Features.Person.Handlers;
using ContactService.Infrastructure.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// 1️⃣ Application Katmanı DI Registrations
builder.Services.AddApplicationServices();

// 2️⃣ Infrastructure Katmanı DI Registrations
builder.Services.AddInfrastructureServices(builder.Configuration);

// 4️⃣ MediatR Ayarları
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePersonCommandHandler).Assembly));

// 5️⃣ Swagger Ayarları
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact Microservice API", Version = "v1" });
});

var app = builder.Build();

// 8️⃣ Development Ortamı İçin Swagger UI Açalım
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact Microservice API V1");
        c.RoutePrefix = string.Empty; // Swagger ana sayfa olsun
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
