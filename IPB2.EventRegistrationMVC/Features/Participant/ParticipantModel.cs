namespace IPB2.EventRegistrationMVC.Features.Participant
{
    #region Request Models
    public class ParticipantCreateRequest
    {
        public string? ParticipantName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class ParticipantUpdateRequest
    {
        public int ParticipantId { get; set; }
        public string? ParticipantName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class ParticipantDeleteRequest
    {
        public int ParticipantId { get; set; }
    }

    public class ParticipantListRequest
    {
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
    }

    public class ParticipantGetByIdRequest
    {
        public int ParticipantId { get; set; }
    }
    #endregion

    #region Response Models
    public class ParticipantResponse
    {
        public int ParticipantId { get; set; }
        public string? ParticipantName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class ParticipantCreateResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ParticipantResponse? Data { get; set; }
    }

    public class ParticipantUpdateResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ParticipantResponse? Data { get; set; }
    }

    public class ParticipantDeleteResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }

    public class ParticipantListResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<ParticipantResponse>? Data { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }

    public class ParticipantGetByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ParticipantResponse? Data { get; set; }
    }
    #endregion
}
