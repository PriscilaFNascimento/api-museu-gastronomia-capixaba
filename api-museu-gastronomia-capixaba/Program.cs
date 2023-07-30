using Data;
using Data.Repositories;
using Domain.Profiles;
using Domain.Repositories;
using Domain.Services;
using Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MuseuGastronomiaCapixabaDbContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"))
    );

builder.Services.AddScoped<IReceitaService, ReceitaService>();
builder.Services.AddScoped<IReceitaRepository, ReceitaRepository>();
builder.Services.AddScoped<IInformacaoNutricionalRepository, InformacaoNutricionalRepository>();

builder.Services.AddAutoMapper(typeof(ReceitaProfile));
builder.Services.AddAutoMapper(typeof(InformacaoNutricionalProfile));

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

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
