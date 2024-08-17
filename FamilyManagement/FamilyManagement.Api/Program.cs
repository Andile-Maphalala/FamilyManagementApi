using Microsoft.EntityFrameworkCore;
using FamilyManagement.Persistence;
using FamilyManagement.Services;
using Microsoft.AspNetCore.Identity;
using FamilyManagement.Domain.Entities;
using FamilyManagement.Persistence.Data;
using static FamilyManagement.Persistence.PersistenceServicesResgistration;
using FamilyManagement.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddUserSecrets<FamailyManagementDbContextFactory>();

// Configure application services
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString"));
});

// Configure controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Identity
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<FamilyManagementDbContext>();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();

app.MapControllers();
app.MapIdentityApi<User>();

app.Run();
