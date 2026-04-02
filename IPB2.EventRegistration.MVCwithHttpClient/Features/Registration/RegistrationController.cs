using Microsoft.AspNetCore.Mvc;
using IPB2.EventRegistration.MVCwithHttpClient.Features.Registration.Models;
using IPB2.EventRegistration.MVCwithHttpClient.Features.Event.Models;
using IPB2.EventRegistration.MVCwithHttpClient.Features.Participant.Models;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPB2.EventRegistration.MVCwithHttpClient.Features.Registration
{
    public class RegistrationController : Controller
    {
        private readonly HttpClient _httpClient;

        public RegistrationController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebApi");
        }

        public async Task<IActionResult> Index(int? eventId)
        {
            var url = $"api/registration/list{(eventId.HasValue ? $"?eventId={eventId}" : "")}";
            var response = await _httpClient.GetFromJsonAsync<RegistrationListResponse>(url);
            
            // Populate ViewBags
            var eventsResp = await _httpClient.GetFromJsonAsync<EventListResponse>("api/event/list?pageSize=100");
            ViewBag.Events = new SelectList(eventsResp?.Data ?? new List<EventResponse>(), "EventId", "EventName", eventId);
            
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            var eventsResp = await _httpClient.GetFromJsonAsync<EventListResponse>("api/event/list?pageSize=100");
            var partsResp = await _httpClient.GetFromJsonAsync<ParticipantListResponse>("api/participant/list?pageSize=100");
            
            ViewBag.Events = new SelectList(eventsResp?.Data ?? new List<EventResponse>(), "EventId", "EventName");
            ViewBag.Participants = new SelectList(partsResp?.Data ?? new List<ParticipantResponse>(), "ParticipantId", "ParticipantName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationCreateRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            var response = await _httpClient.PostAsJsonAsync("api/registration/register", request);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest("Error registering participant.");
        }

        public async Task<IActionResult> Edit(int id)
        {
            // We just need the Registration status for editing.
            var response = await _httpClient.GetFromJsonAsync<RegistrationListResponse>($"api/registration/list");
            var reg = response?.Data?.FirstOrDefault(r => r.RegistrationId == id);
            if (reg == null) return NotFound();
            
            return View(new RegistrationUpdateRequest { RegistrationId = reg.RegistrationId, Status = reg.Status });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegistrationUpdateRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            var response = await _httpClient.PutAsJsonAsync("api/registration/update", request);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var response = await _httpClient.PutAsync($"api/registration/cancel/{id}", null);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest("Error cancelling registration.");
        }
    }
}
