using IPB2.EventRegistration.MVCwithHttpClient.Features.Event.Models;
using IPB2.EventRegistration.MVCwithHttpClient.Features.Participant.Models;

namespace IPB2.EventRegistration.MVCwithHttpClient.Features.Report.Models
{
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
}
