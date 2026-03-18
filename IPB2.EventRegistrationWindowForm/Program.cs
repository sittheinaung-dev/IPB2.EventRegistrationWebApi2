using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;
using IPB2.EventRegistrationWebApi.Features.Event;
using IPB2.EventRegistrationWebApi.Features.Participant;
using IPB2.EventRegistrationWebApi.Features.Registration;
using IPB2.EventRegistrationWebApi.Features.Report;
using IPB2.EventRegistrationWindowForm.Features.Main;
using IPB2.EventRegistrationWindowForm.Features.Event;
using IPB2.EventRegistrationWindowForm.Features.Participant;
using IPB2.EventRegistrationWindowForm.Features.Registration;
using IPB2.EventRegistrationWindowForm.Features.Report;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IPB2.EventRegistrationWindowForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Database
                    services.AddDbContext<AppDbContext>();

                    // Services
                    services.AddScoped<EventServices>();
                    services.AddScoped<ParticipantServices>();
                    services.AddScoped<RegistrationServices>();
                    services.AddScoped<ReportServices>();

                    // Forms
                    services.AddTransient<MainForm>();
                    services.AddTransient<EventForm>();
                    services.AddTransient<ParticipantForm>();
                    services.AddTransient<RegistrationForm>();
                    services.AddTransient<ReportForm>();
                })
                .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var mainForm = services.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }
    }
}