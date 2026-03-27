namespace IPB2.EventRegistrationMVC.Features.Registration
{
    #region Request Models
    public class RegistrationCreateRequest
    {
        public int EventId { get; set; }
        public int ParticipantId { get; set; }
    }

    public class RegistrationUpdateRequest
    {
        public int RegistrationId { get; set; }
        public string? Status { get; set; }
    }

    public class RegistrationCancelRequest
    {
        public int RegistrationId { get; set; }
    }

    public class RegistrationListRequest
    {
        public int? EventId { get; set; }
    }
    #endregion

    #region Response Models
    public class RegistrationResponse
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public int ParticipantId { get; set; }
        public string? ParticipantName { get; set; }
        public DateTime RegisterDate { get; set; }
        public string? Status { get; set; }
    }

    public class RegistrationCreateResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public RegistrationResponse? Data { get; set; }
    }

    public class RegistrationUpdateResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public RegistrationResponse? Data { get; set; }
    }

    public class RegistrationCancelResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }

    public class RegistrationListResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<RegistrationResponse>? Data { get; set; }
        public int TotalCount { get; set; }
    }
    #endregion
}
