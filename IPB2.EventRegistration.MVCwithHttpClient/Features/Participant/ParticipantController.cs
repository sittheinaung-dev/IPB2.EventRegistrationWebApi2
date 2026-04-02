using Microsoft.AspNetCore.Mvc;
using IPB2.EventRegistration.MVCwithHttpClient.Features.Participant.Models;
using System.Net.Http.Json;

namespace IPB2.EventRegistration.MVCwithHttpClient.Features.Participant
{
    public class ParticipantController : Controller
    {
        private readonly HttpClient _httpClient;

        public ParticipantController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("WebApi");
        }

        public async Task<IActionResult> Index(int? pageNo, int? pageSize)
        {
            var url = $"api/participant/list?pageNo={pageNo ?? 1}&pageSize={pageSize ?? 10}";
            var response = await _httpClient.GetFromJsonAsync<ParticipantListResponse>(url);
            return View(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ParticipantGetByIdResponse>($"api/participant/{id}");
            if (response == null || !response.IsSuccess) return NotFound();
            return View(response.Data);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ParticipantCreateRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            var response = await _httpClient.PostAsJsonAsync("api/participant/create", request);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ParticipantGetByIdResponse>($"api/participant/{id}");
            if (response == null || !response.IsSuccess) return NotFound();
            var editRequest = new ParticipantUpdateRequest
            {
                ParticipantId = response.Data!.ParticipantId,
                ParticipantName = response.Data.ParticipantName,
                Email = response.Data.Email,
                Phone = response.Data.Phone
            };
            return View(editRequest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ParticipantUpdateRequest request)
        {
            if (!ModelState.IsValid) return View(request);
            var response = await _httpClient.PutAsJsonAsync("api/participant/update", request);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ParticipantGetByIdResponse>($"api/participant/{id}");
            if (response == null || !response.IsSuccess) return NotFound();
            return View(response.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/participant/delete/{id}");
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Delete), new { id });
        }
    }
}
