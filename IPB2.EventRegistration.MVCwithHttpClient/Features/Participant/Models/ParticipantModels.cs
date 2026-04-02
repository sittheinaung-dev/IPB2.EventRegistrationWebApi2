namespace IPB2.EventRegistration.MVCwithHttpClient.Features.Participant.Models
{
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

    public class ParticipantResponse
    {
        public int ParticipantId { get; set; }
        public string? ParticipantName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    public class ParticipantListResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<ParticipantResponse>? Data { get; set; }
        public int TotalCount { get; set; }
    }

    public class ParticipantGetByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public ParticipantResponse? Data { get; set; }
    }
}
