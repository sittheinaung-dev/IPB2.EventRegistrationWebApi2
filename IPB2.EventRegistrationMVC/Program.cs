using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;
using IPB2.EventRegistrationMVC.Features.Event;
using IPB2.EventRegistrationMVC.Features.Participant;
using IPB2.EventRegistrationMVC.Features.Registration;
using IPB2.EventRegistrationMVC.Features.Report;
using IPB2.EventRegistrationMVC.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<EventServices>();
builder.Services.AddScoped<ParticipantServices>();
builder.Services.AddScoped<RegistrationServices>();
builder.Services.AddScoped<ReportServices>();

builder.Services.AddControllersWithViews()
    .AddRazorOptions(options =>
    {
        options.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
    });

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
    pattern: "{controller=Event}/{action=Index}/{id?}");

app.Run();
