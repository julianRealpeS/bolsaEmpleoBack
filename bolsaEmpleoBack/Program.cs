using bolsaEmpleoBack.Models;
using bolsaEmpleoBack.Repository;
using bolsaEmpleoBack.Repository.Impl;
using bolsaEmpleoBack.Services;
using bolsaEmpleoBack.Services.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add repository to the container.
builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
builder.Services.AddScoped<ICiudadanoRepository, CiudadanoRepository>();
builder.Services.AddScoped<IVacanteOfertadaRepository, VacanteOfertadaRepository>();

// Add services to the container.
builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
builder.Services.AddScoped<ICiudadanoService, CiudadanoService>();
builder.Services.AddScoped<IVacanteOfertadaService, VacanteOfertadaService>();

// Add controllers to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Entity framework
builder.Services.AddDbContext<BolsaEmpleoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BolsaEmpleoDbContext"));
});

var app = builder.Build();

//Cors configuration
const string cors = "CORS_MODE_UNRESTRICTED";
app.UseCors(cors);

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
