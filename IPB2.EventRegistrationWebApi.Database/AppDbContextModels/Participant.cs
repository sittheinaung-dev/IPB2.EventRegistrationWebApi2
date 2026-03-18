using System;
using System.Collections.Generic;

namespace IPB2.EventRegistrationWebApi.Database.AppDbContextModels;

public partial class Participant
{
    public int ParticipantId { get; set; }

    public string? ParticipantName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? IsDelete { get; set; }
}
