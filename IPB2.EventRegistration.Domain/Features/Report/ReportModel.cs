using IPB2.EventRegistration.Domain.Features.Event;
using IPB2.EventRegistration.Domain.Features.Participant;

namespace IPB2.EventRegistration.Domain.Features.Report
{
    #region Request Models
    public class AvailableEventsRequest
    {
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
    }

    public class ParticipantsByEventRequest
    {
        public int EventId { get; set; }
    }

    public class SearchEventsRequest
    {
        public string? SearchTerm { get; set; }
    }
    #endregion

    #region Response Models
    public class AvailableEventsResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<EventResponse>? Data { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }

    public class ParticipantsByEventResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<ParticipantResponse>? Data { get; set; }
    }

    public class SearchEventsResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<EventResponse>? Data { get; set; }
    }
    #endregion
}
