using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;
using IPB2.EventRegistration.Domain.Features.Event;
using IPB2.EventRegistration.Domain.Features.Participant;
using IPB2.EventRegistration.Domain.Features.Registration;
using IPB2.EventRegistration.Domain.Features.Report;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped<EventServices>();
        services.AddScoped<ParticipantServices>();
        services.AddScoped<RegistrationServices>();
        services.AddScoped<ReportServices>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

var eventServices = services.GetRequiredService<EventServices>();
var participantServices = services.GetRequiredService<ParticipantServices>();
var registrationServices = services.GetRequiredService<RegistrationServices>();
var reportServices = services.GetRequiredService<ReportServices>();

bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine("======================================");
    Console.WriteLine("   EVENT REGISTRATION SYSTEM");
    Console.WriteLine("======================================");
    Console.WriteLine("1. Event Management");
    Console.WriteLine("2. Participant Management");
    Console.WriteLine("3. Registration Management");
    Console.WriteLine("4. Reports");
    Console.WriteLine("5. Exit");
    Console.WriteLine("======================================");
    Console.Write("Enter your choice: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            await EventMenu(eventServices);
            break;
        case "2":
            await ParticipantMenu(participantServices);
            break;
        case "3":
            await RegistrationMenu(registrationServices);
            break;
        case "4":
            await ReportMenu(reportServices);
            break;
        case "5":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice. Press any key to try again...");
            Console.ReadKey();
            break;
    }
}

async Task EventMenu(EventServices eventServices)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Event Management ---");
        Console.WriteLine("1. List Events");
        Console.WriteLine("2. Create Event");
        Console.WriteLine("3. Update Event");
        Console.WriteLine("4. Delete Event");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Choice: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var list = await eventServices.GetEvents(new EventListRequest());
                if (list.IsSuccess && list.Data != null)
                {
                    foreach (var item in list.Data)
                    {
                        Console.WriteLine($"ID: {item.EventId} | Name: {item.EventName} | Date: {item.EventDate:yyyy-MM-dd} | Loc: {item.Location}");
                    }
                }
                else Console.WriteLine("No events found.");
                Console.WriteLine("Press any key..."); Console.ReadKey();
                break;
            case "2":
                Console.Write("Name: "); var name = Console.ReadLine();
                Console.Write("Location: "); var loc = Console.ReadLine();
                Console.Write("Date (yyyy-mm-dd): "); var dateInput = Console.ReadLine();
                var createRes = await eventServices.CreateEvent(new EventCreateRequest 
                { 
                    EventName = name ?? "", 
                    Location = loc ?? "", 
                    EventDate = DateTime.TryParse(dateInput, out var d) ? DateOnly.FromDateTime(d) : null 
                });
                Console.WriteLine(createRes.Message);
                Console.ReadKey();
                break;
            case "3":
                Console.Write("Event ID to Update: "); int upId = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("New Name: "); var upName = Console.ReadLine();
                Console.Write("New Location: "); var upLoc = Console.ReadLine();
                Console.Write("New Date (yyyy-mm-dd): "); var upDateInput = Console.ReadLine();
                var upRes = await eventServices.UpdateEvent(new EventUpdateRequest 
                { 
                    EventId = upId, 
                    EventName = upName ?? "", 
                    Location = upLoc ?? "", 
                    EventDate = DateTime.TryParse(upDateInput, out var ud) ? DateOnly.FromDateTime(ud) : null 
                });
                Console.WriteLine(upRes.Message);
                Console.ReadKey();
                break;
            case "4":
                Console.Write("Event ID to Delete: "); int delId = int.Parse(Console.ReadLine() ?? "0");
                var delRes = await eventServices.DeleteEvent(new EventDeleteRequest { EventId = delId });
                Console.WriteLine(delRes.Message);
                Console.ReadKey();
                break;
            case "5": back = true; break;
        }
    }
}

async Task ParticipantMenu(ParticipantServices participantServices)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Participant Management ---");
        Console.WriteLine("1. List Participants");
        Console.WriteLine("2. Create Participant");
        Console.WriteLine("3. Update Participant");
        Console.WriteLine("4. Delete Participant");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Choice: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var list = await participantServices.GetParticipants(new ParticipantListRequest());
                if (list.IsSuccess && list.Data != null)
                {
                    foreach (var item in list.Data)
                        Console.WriteLine($"ID: {item.ParticipantId} | Name: {item.ParticipantName} | Email: {item.Email}");
                }
                Console.ReadKey();
                break;
            case "2":
                Console.Write("Name: "); var n = Console.ReadLine();
                Console.Write("Email: "); var e = Console.ReadLine();
                Console.Write("Phone: "); var p = Console.ReadLine();
                var res = await participantServices.CreateParticipant(new ParticipantCreateRequest { ParticipantName = n ?? "", Email = e ?? "", Phone = p ?? "" });
                Console.WriteLine(res.Message);
                Console.ReadKey();
                break;
            case "3":
                Console.Write("Participant ID to Update: "); int pUpId = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("New Name: "); var pUpName = Console.ReadLine();
                Console.Write("New Email: "); var pUpEmail = Console.ReadLine();
                Console.Write("New Phone: "); var pUpPhone = Console.ReadLine();
                var pUpRes = await participantServices.UpdateParticipant(new ParticipantUpdateRequest { ParticipantId = pUpId, ParticipantName = pUpName ?? "", Email = pUpEmail ?? "", Phone = pUpPhone ?? "" });
                Console.WriteLine(pUpRes.Message);
                Console.ReadKey();
                break;
            case "4":
                Console.Write("Participant ID to Delete: "); int pDelId = int.Parse(Console.ReadLine() ?? "0");
                var pDelRes = await participantServices.DeleteParticipant(new ParticipantDeleteRequest { ParticipantId = pDelId });
                Console.WriteLine(pDelRes.Message);
                Console.ReadKey();
                break;
            case "5": back = true; break;
        }
    }
}

async Task RegistrationMenu(RegistrationServices registrationServices)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Registration Management ---");
        Console.WriteLine("1. List Registrations");
        Console.WriteLine("2. Register Participant for Event");
        Console.WriteLine("3. Update Registration Status");
        Console.WriteLine("4. Cancel Registration");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Choice: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var list = await registrationServices.GetRegistrations(new RegistrationListRequest());
                if (list.IsSuccess && list.Data != null)
                {
                    foreach (var item in list.Data)
                        Console.WriteLine($"ID: {item.RegistrationId} | Event: {item.EventName} | Participant: {item.ParticipantName} | Status: {item.Status} | Date: {item.RegisterDate}");
                }
                Console.ReadKey();
                break;
            case "2":
                Console.Write("Event ID: "); int eid = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Participant ID: "); int pid = int.Parse(Console.ReadLine() ?? "0");
                var res = await registrationServices.RegisterParticipant(new RegistrationCreateRequest { EventId = eid, ParticipantId = pid });
                Console.WriteLine(res.Message);
                Console.ReadKey();
                break;
            case "3":
                Console.Write("Registration ID to Update: "); int rUpId = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("New Status: "); var rStatus = Console.ReadLine();
                var rUpRes = await registrationServices.UpdateRegistration(new RegistrationUpdateRequest { RegistrationId = rUpId, Status = rStatus ?? "" });
                Console.WriteLine(rUpRes.Message);
                Console.ReadKey();
                break;
            case "4":
                Console.Write("Registration ID to Cancel: "); int rCanId = int.Parse(Console.ReadLine() ?? "0");
                var rCanRes = await registrationServices.CancelRegistration(new RegistrationCancelRequest { RegistrationId = rCanId });
                Console.WriteLine(rCanRes.Message);
                Console.ReadKey();
                break;
            case "5": back = true; break;
        }
    }
}

async Task ReportMenu(ReportServices reportServices)
{
    bool back = false;
    while (!back)
    {
        Console.Clear();
        Console.WriteLine("--- Reports ---");
        Console.WriteLine("1. Available Events");
        Console.WriteLine("2. Search Events");
        Console.WriteLine("3. Participants by Event");
        Console.WriteLine("4. Back to Main Menu");
        Console.Write("Choice: ");
        string? choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                var res = await reportServices.GetAvailableEvents(new AvailableEventsRequest());
                if (res.IsSuccess && res.Data != null)
                {
                    foreach (var item in res.Data)
                        Console.WriteLine($"Event: {item.EventName} | Date: {item.EventDate:yyyy-MM-dd} | Status: {item.Status}");
                }
                Console.ReadKey();
                break;
            case "2":
                Console.Write("Search Term: "); var term = Console.ReadLine();
                var sres = await reportServices.SearchEvents(new SearchEventsRequest { SearchTerm = term ?? "" });
                if (sres.IsSuccess && sres.Data != null)
                {
                    foreach (var item in sres.Data)
                        Console.WriteLine($"{item.EventName} | {item.Location} | {item.EventDate:yyyy-MM-dd}");
                }
                Console.ReadKey();
                break;
            case "3":
                Console.Write("Event ID: "); int repEid = int.Parse(Console.ReadLine() ?? "0");
                var prepRes = await reportServices.GetParticipantsByEvent(new ParticipantsByEventRequest { EventId = repEid });
                if (prepRes.IsSuccess && prepRes.Data != null)
                {
                    foreach (var p in prepRes.Data)
                        Console.WriteLine($"ID: {p.ParticipantId} | Name: {p.ParticipantName} | Email: {p.Email}");
                }
                Console.ReadKey();
                break;
            case "4": back = true; break;
        }
    }
}
