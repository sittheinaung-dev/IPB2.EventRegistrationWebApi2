using System;
using System.Collections.Generic;

namespace IPB2.EventRegistrationWebApi.Database.AppDbContextModels;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public DateOnly? EventDate { get; set; }

    public string? Location { get; set; }

    public string? Status { get; set; }

    public bool? IsDelete { get; set; }
}
