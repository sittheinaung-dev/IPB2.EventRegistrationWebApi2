using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;
using IPB2.EventRegistrationWebApi.Features.Event;
using IPB2.EventRegistrationWebApi.Features.Participant;
using IPB2.EventRegistrationWebApi.Features.Registration;
using IPB2.EventRegistrationWebApi.Features.Report;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<EventServices>();
builder.Services.AddScoped<ParticipantServices>();
builder.Services.AddScoped<RegistrationServices>();
builder.Services.AddScoped<ReportServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Event Endpoints
var eventGroup = app.MapGroup("/api/event");

eventGroup.MapPost("/create", async (EventCreateRequest request, EventServices services) =>
{
    var response = await services.CreateEvent(request);
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

eventGroup.MapPut("/update", async (EventUpdateRequest request, EventServices services) =>
{
    var response = await services.UpdateEvent(request);
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

eventGroup.MapDelete("/delete/{id}", async (int id, EventServices services) =>
{
    var response = await services.DeleteEvent(new EventDeleteRequest { EventId = id });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

eventGroup.MapGet("/list", async ([FromQuery] int? pageNo, [FromQuery] int? pageSize, EventServices services) =>
{
    var response = await services.GetEvents(new EventListRequest { PageNo = pageNo, PageSize = pageSize });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

eventGroup.MapGet("/{id}", async (int id, EventServices services) =>
{
    var response = await services.GetEventById(new EventGetByIdRequest { EventId = id });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});
#endregion

#region Participant Endpoints
var participantGroup = app.MapGroup("/api/participant");

participantGroup.MapPost("/create", async (ParticipantCreateRequest request, ParticipantServices services) =>
{
    var response = await services.CreateParticipant(request);
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

participantGroup.MapPut("/update", async (ParticipantUpdateRequest request, ParticipantServices services) =>
{
    var response = await services.UpdateParticipant(request);
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

participantGroup.MapDelete("/delete/{id}", async (int id, ParticipantServices services) =>
{
    var response = await services.DeleteParticipant(new ParticipantDeleteRequest { ParticipantId = id });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

participantGroup.MapGet("/list", async ([FromQuery] int? pageNo, [FromQuery] int? pageSize, ParticipantServices services) =>
{
    var response = await services.GetParticipants(new ParticipantListRequest { PageNo = pageNo, PageSize = pageSize });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

participantGroup.MapGet("/{id}", async (int id, ParticipantServices services) =>
{
    var response = await services.GetParticipantById(new ParticipantGetByIdRequest { ParticipantId = id });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});
#endregion

#region Registration Endpoints
var registrationGroup = app.MapGroup("/api/registration");

registrationGroup.MapPost("/register", async (RegistrationCreateRequest request, RegistrationServices services) =>
{
    var response = await services.RegisterParticipant(request);
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

registrationGroup.MapPut("/update", async (RegistrationUpdateRequest request, RegistrationServices services) =>
{
    var response = await services.UpdateRegistration(request);
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

registrationGroup.MapPut("/cancel/{id}", async (int id, RegistrationServices services) =>
{
    var response = await services.CancelRegistration(new RegistrationCancelRequest { RegistrationId = id });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

registrationGroup.MapGet("/list", async ([FromQuery] int? eventId, RegistrationServices services) =>
{
    var response = await services.GetRegistrations(new RegistrationListRequest { EventId = eventId });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});
#endregion

#region Report Endpoints
var reportGroup = app.MapGroup("/api/report");

reportGroup.MapGet("/available-events", async ([FromQuery] int? pageNo, [FromQuery] int? pageSize, ReportServices services) =>
{
    var response = await services.GetAvailableEvents(new AvailableEventsRequest { PageNo = pageNo, PageSize = pageSize });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

reportGroup.MapGet("/participants-by-event/{eventId}", async (int eventId, ReportServices services) =>
{
    var response = await services.GetParticipantsByEvent(new ParticipantsByEventRequest { EventId = eventId });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});

reportGroup.MapGet("/search-events", async ([FromQuery] string searchTerm, ReportServices services) =>
{
    var response = await services.SearchEvents(new SearchEventsRequest { SearchTerm = searchTerm });
    return response.IsSuccess ? Results.Ok(response) : Results.BadRequest(response);
});
#endregion

app.Run();
