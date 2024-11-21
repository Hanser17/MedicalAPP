using MedicalAppoiments.Persistance.Context;
using MedicalAppoiments.Persistance.Interfaces.Iappointments;
using MedicalAppoiments.Persistance.Interfaces.Iinsurance;
using MedicalAppoiments.Persistance.Interfaces.Imedical;
using MedicalAppoiments.Persistance.Interfaces.Isystem;
using MedicalAppoiments.Persistance.Interfaces.Iusers;
using MedicalAppoiments.Persistance.Repositories.appointmentsRepository;
using MedicalAppoiments.Persistance.Repositories.insuranceRepository;
using MedicalAppoiments.Persistance.Repositories.medicalRepository;
using MedicalAppoiments.Persistance.Repositories.systemRepository;
using MedicalAppoiments.Persistance.Repositories.usersRepository;
using MedicalAppointment.Application.Interfaces.IappointmentsService;
using MedicalAppointment.Application.Interfaces.IinsuranceService;
using MedicalAppointment.Application.Interfaces.ImedicalService;
using MedicalAppointment.Application.Interfaces.IsystemService;
using MedicalAppointment.Application.Interfaces.Iusersservice;
using MedicalAppointment.Application.Service.appointments.Service;
using MedicalAppointment.Application.Service.insurance.Service;
using MedicalAppointment.Application.Service.medical.Service;
using MedicalAppointment.Application.Service.system;
using MedicalAppointment.Application.Service.system.Service;
using MedicalAppointment.Application.Service.users.service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// Add services to the container.
builder.Services.AddDbContext<MedicalAppointmentContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MedicalAppointmentDB")));

//El registro de cada una de las dependecias Repositorios de configuration. //
builder.Services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
builder.Services.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();

builder.Services.AddTransient<IDoctorAvailabilityService, DoctorAvailabilityService>();
builder.Services.AddTransient<IAppointmentsService, AppointmentsService>();



builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();
builder.Services.AddScoped<IPatientsRepository, PatientsRepositoy>();

builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IDoctorService, DoctorService>();
builder.Services.AddTransient<IPatientService, PatientService>();


builder.Services.AddScoped<IInsuranceProvidersRepository, InsuranceProvidersRepository>();
builder.Services.AddScoped<INetworkTypeRepository, NetworkTypeRepository>();

builder.Services.AddTransient<IInsuranceProvidersService, InsuranceProvidersService>();
builder.Services.AddTransient<INetworkTypeService, NetworkTypeService>();

//----- IVERSON INYECCION DE DEPENDENCIA
builder.Services.AddTransient<INotificationsRepository, NotificationsRepository>();
builder.Services.AddTransient<IRolesRepository, RolesRepository>();
builder.Services.AddTransient<IStatusRepositoty, StatusRepositoty>();

builder.Services.AddTransient<INotificationsService, NotificationsService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<IStatusService, StatusService>();

//----- ANDERSON INYECCION DE DEPENDENCIA
builder.Services.AddTransient<IAvailabilityModesRepository, AvailabilityModesRepository>();
builder.Services.AddTransient<IMedicalRecordsRepository, MedicalRecordsRepository>();
builder.Services.AddTransient<ISpecialtiesRepository, SpecialtiesRepository>();

builder.Services.AddTransient<IAvailabilityModesService, AvailabilityModesService >();
builder.Services.AddTransient<IMedicalRecordsService, MedicalRecordsService>();
builder.Services.AddTransient<ISpecialtiesService, SpecialtiesService >();




builder.Services.AddAutoMapper( typeof(MedicalAppointment.Application.Mapper_Profile.MapperProfile).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
