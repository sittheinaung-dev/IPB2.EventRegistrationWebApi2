using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;
using IPB2.EventRegistration.Domain.Features.Event;
using IPB2.EventRegistration.Domain.Features.Participant;
using IPB2.EventRegistration.Domain.Features.Registration;
using IPB2.EventRegistration.Domain.Features.Report;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<EventServices>();
builder.Services.AddScoped<ParticipantServices>();
builder.Services.AddScoped<RegistrationServices>();
builder.Services.AddScoped<ReportServices>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
