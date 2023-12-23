using Microsoft.AspNetCore.Authentication.Cookies;
using SysManageCRUD.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPatientRepository, PatientRepository>(); 
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>(); 
builder.Services.AddScoped<ILocationRepository, LocationRepository>(); 
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>(); 
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    options.Cookie.Name = "CookieAutentication";
    options.LoginPath = "/Front/Access/Access";
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Front/Acess/ErrorAccess"; 
}); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Front}/{controller=Start}/{action=Index}/{id?}");

app.Run();
