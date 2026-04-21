using RestApiWithAspNet10.Configurations;
using RestApiWithAspNet10.Repositories;
using RestApiWithAspNet10.Repositories.Implementation;
using RestApiWithAspNet10.Service;
using RestApiWithAspNet10.Service.Implementation;


var builder = WebApplication.CreateBuilder(args);

builder.AddSerilogLogging();

builder.Services.AddControllers().AddContentNegotiation();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddOpenAPIConfig();

builder.Services.AddSwaggerConfig();

builder.Services.AddRouteConfig();

builder.Services.AddDatabaseConfiguration(builder.Configuration);

builder.Services.AddEvolveConfiguration(builder.Configuration, builder.Environment);

builder.Services.AddScoped<IPersonServices, PersonServicesImplementation>();

builder.Services.AddScoped<IBookServices, BookServicesImplementation>();

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwaggerConfiguration();

app.UseScalarConfiguration();

app.Run();
