namespace IPB2.EventRegistration.MVCwithHttpClient.Features.Event.Models
{
    public class EventCreateRequest
    {
        public string? EventName { get; set; }
        public string? Location { get; set; }
        public DateOnly? EventDate { get; set; }
        public string? Status { get; set; }
    }

    public class EventUpdateRequest
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? Location { get; set; }
        public DateOnly? EventDate { get; set; }
        public string? Status { get; set; }
    }

    public class EventResponse
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? Location { get; set; }
        public DateOnly? EventDate { get; set; }
        public string? Status { get; set; }
    }

    public class EventListResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<EventResponse>? Data { get; set; }
        public int TotalCount { get; set; }
    }

    public class EventGetByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public EventResponse? Data { get; set; }
    }
}
