using System;
using System.Collections.Generic;

namespace IPB2.EventRegistrationWebApi.Database.AppDbContextModels;

public partial class Registration
{
    public int RegistrationId { get; set; }

    public int? EventId { get; set; }

    public int? ParticipantId { get; set; }

    public DateOnly? RegisterDate { get; set; }

    public string? Status { get; set; }
}
