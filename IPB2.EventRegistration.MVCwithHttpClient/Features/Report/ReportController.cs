using Microsoft.AspNetCore.Mvc;
using IPB2.EventRegistration.MVCwithHttpClient.Features.Report.Models;
using System.Net.Http.Json;

namespace IPB2.EventRegistration.MVCwithHttpClient.Features.Report
{
    public class ReportController : Controller
    {
        private readonly HttpClient _httpClient;

        public ReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebApi");
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> AvailableEvents(int? pageNo, int? pageSize)
        {
            var url = $"api/report/available-events?pageNo={pageNo ?? 1}&pageSize={pageSize ?? 10}";
            var response = await _httpClient.GetFromJsonAsync<AvailableEventsResponse>(url);
            return View(response);
        }

        public async Task<IActionResult> ParticipantsByEvent(int? eventId)
        {
            // Populate ViewBags for the select list
            var eventsResp = await _httpClient.GetFromJsonAsync<IPB2.EventRegistration.MVCwithHttpClient.Features.Event.Models.EventListResponse>("api/event/list?pageSize=100");
            ViewBag.Events = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                eventsResp?.Data ?? new List<IPB2.EventRegistration.MVCwithHttpClient.Features.Event.Models.EventResponse>(),
                "EventId", "EventName", eventId);

            if (!eventId.HasValue || eventId.Value <= 0)
            {
                return View(new ParticipantsByEventResponse { Data = new List<IPB2.EventRegistration.MVCwithHttpClient.Features.Participant.Models.ParticipantResponse>() });
            }

            var url = $"api/report/participants-by-event/{eventId}";
            var response = await _httpClient.GetFromJsonAsync<ParticipantsByEventResponse>(url);
            return View(response);
        }

        public async Task<IActionResult> SearchEvents(string? searchTerm)
        {
            var url = $"api/report/search-events?searchTerm={searchTerm ?? string.Empty}";
            var response = await _httpClient.GetFromJsonAsync<SearchEventsResponse>(url);
            return View(response);
        }
    }
}
