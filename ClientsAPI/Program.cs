using ClientsAPI.Context;
using ClientsAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

void ConfigureServices(IServiceCollection services)
{
    services.AddSwaggerGen(swagger =>
    {
        swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "ClientsAPI" });
        var documentationWebAPI = Path.Combine(AppContext.BaseDirectory, "ClientsAPI.xml");
        var documentationModels = Path.Combine(AppContext.BaseDirectory, "ClientsAPI.Repositories.xml");
        swagger.IncludeXmlComments(documentationModels);
        swagger.IncludeXmlComments(documentationWebAPI);
    });
}

builder.Services.AddDbContext<ClientContext>(x => x.UseSqlite("Data source-client.db"));
builder.Services.AddScoped<IClientRepository, ClientRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
