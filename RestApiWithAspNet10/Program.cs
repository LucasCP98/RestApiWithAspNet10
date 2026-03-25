
using RestApiWithAspNet10.Controllers.Service.Implementation;
using RestApiWithAspNet10.Controllers.Service;
using RestApiWithAspNet10.Configurations;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddScoped<IPersonServices, PersonServicesImplementation>();
// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
