using Consultorio_Medico.BL.Interfaces;
using Consultorio_Medico.Blazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRadzenComponents();
builder.Services.AddSingleton<RolService>();
builder.Services.AddSingleton<SecurityService>();
builder.Services.AddSingleton<ScheduleService>();
builder.Services.AddSingleton<PatientService>();
builder.Services.AddSingleton<SpecialtyService>();
builder.Services.AddSingleton<UserScheduleService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<AppointmentService>();
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddScoped<Radzen.NotificationService>();
//builder.Services.AddScoped<ISecurityBL>();

builder.Services.AddHttpClient("MEDICOAPI", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["UrlsAPI:MEDICOAPI"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
