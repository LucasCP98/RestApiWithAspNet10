using RestApiWithAspNet10.Controllers.Service.Implementation;
using RestApiWithAspNet10.Controllers.Service;
using RestApiWithAspNet10.Configurations;
using RestApiWithAspNet10.Repositories;
using RestApiWithAspNet10.Repositories.Implementation;


var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddScoped<IPersonServices, PersonServicesImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
