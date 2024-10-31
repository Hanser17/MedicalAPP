using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iinsurance;
using MedicalAppoiments.Persistance.Repositories.insuranceRepository;
using MedicalAppointment.Application.Interfaces.IinsuranceService;
using MedicalAppointment.Application.Service.insurance.Service;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalAppointmentDB")));

//El registro de cada una de las dependecias Repositorios de configuration. //
builder.Services.AddScoped<IInsuranceProvidersRepository, InsuranceProvidersRepository>();
builder.Services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();

builder.Services.AddScoped<IInsuranceProvidersService, InsuranceProvidersService>();
builder.Services.AddScoped<INetworkTypeService, NetworkTypeService>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
