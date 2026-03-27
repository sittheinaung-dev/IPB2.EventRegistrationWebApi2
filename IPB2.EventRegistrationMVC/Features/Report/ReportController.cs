using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPB2.EventRegistrationMVC.Features.Report
{
    public class ReportController : Controller
    {
        private readonly ReportServices _reportServices;

        public ReportController(ReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        public async Task<IActionResult> AvailableEvents(int? pageNo, int? pageSize)
        {
            var request = new AvailableEventsRequest { PageNo = pageNo ?? 1, PageSize = pageSize ?? 10 };
            var response = await _reportServices.GetAvailableEvents(request);
            return View(response);
        }

        public async Task<IActionResult> ParticipantsByEvent(int? eventId)
        {
            ViewBag.Events = new SelectList(await _reportServices.GetActiveEvents(), "EventId", "EventName", eventId);
            
            if (!eventId.HasValue)
            {
                return View(new ParticipantsByEventResponse { IsSuccess = true, Data = new List<IPB2.EventRegistrationMVC.Features.Participant.ParticipantResponse>() });
            }

            var request = new ParticipantsByEventRequest { EventId = eventId.Value };
            var response = await _reportServices.GetParticipantsByEvent(request);
            return View(response);
        }

        public async Task<IActionResult> SearchEvents(string? searchTerm)
        {
            var request = new SearchEventsRequest { SearchTerm = searchTerm };
            var response = await _reportServices.SearchEvents(request);
            return View(response);
        }
    }
}
