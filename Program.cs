using Microsoft.EntityFrameworkCore;
using WingsAir_API.Dependency;
using WingsAir_API.Models;
using WingsAir_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//inyecto el contexto creado con EF al constructor de la aplicación para que se conecte
builder.Services.AddDbContext<Aeropuerto_WingsAirContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQL_Connection_remote"), sqlServerOptionsAction: sqloption =>
{
    sqloption.EnableRetryOnFailure(
        maxRetryCount: 10,
        maxRetryDelay: TimeSpan.FromSeconds(10),
        errorNumbersToAdd: null);
}));
//Inyección de dependecias (Scoped<Intefaz, Servicio>)
builder.Services.AddScoped<IVuelos, VuelosService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//CORS
builder.Services.AddCors(option => option.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");
app.UseAuthorization();

app.MapControllers();

app.Run();
