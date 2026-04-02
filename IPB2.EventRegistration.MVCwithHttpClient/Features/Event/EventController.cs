using Microsoft.AspNetCore.Mvc;
using IPB2.EventRegistration.MVCwithHttpClient.Features.Event.Models;
using System.Net.Http.Json;

namespace IPB2.EventRegistration.MVCwithHttpClient.Features.Event
{
    public class EventController : Controller
    {
        private readonly HttpClient _httpClient;

        public EventController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebApi");
        }

        public async Task<IActionResult> Index(int? pageNo, int? pageSize)
        {
            var url = $"api/event/list?pageNo={pageNo ?? 1}&pageSize={pageSize ?? 10}";
            var response = await _httpClient.GetFromJsonAsync<EventListResponse>(url);
            return View(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<EventGetByIdResponse>($"api/event/{id}");
            if (response == null || !response.IsSuccess) return NotFound();
            return View(response.Data);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            var response = await _httpClient.PostAsJsonAsync("api/event/create", request);
            var result = await response.Content.ReadFromJsonAsync<dynamic>(); // Simplified for now
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<EventGetByIdResponse>($"api/event/{id}");
            if (response == null || !response.IsSuccess) return NotFound();
            var editRequest = new EventUpdateRequest
            {
                EventId = response.Data!.EventId,
                EventName = response.Data.EventName,
                Location = response.Data.Location,
                EventDate = response.Data.EventDate,
                Status = response.Data.Status
            };
            return View(editRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EventUpdateRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            var response = await _httpClient.PutAsJsonAsync("api/event/update", request);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<EventGetByIdResponse>($"api/event/{id}");
            if (response == null || !response.IsSuccess) return NotFound();
            return View(response.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/event/delete/{id}");
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
