using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;

namespace IPB2.EventRegistrationMVC.Features.Event
{
    #region Request Models
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

    public class EventDeleteRequest
    {
        public int EventId { get; set; }
    }

    public class EventListRequest
    {
        public int? PageNo { get; set; }
        public int? PageSize { get; set; }
    }

    public class EventGetByIdRequest
    {
        public int EventId { get; set; }
    }
    #endregion

    #region Response Models
    public class EventResponse
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? Location { get; set; }
        public DateOnly? EventDate { get; set; }
        public string? Status { get; set; }
    }

    public class EventCreateResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public EventResponse? Data { get; set; }
    }

    public class EventUpdateResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public EventResponse? Data { get; set; }
    }

    public class EventDeleteResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }

    public class EventListResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public List<EventResponse>? Data { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }

    public class EventGetByIdResponse
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public EventResponse? Data { get; set; }
    }
    #endregion
}
