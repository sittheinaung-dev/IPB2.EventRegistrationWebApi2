using Microsoft.AspNetCore.Mvc;
using IPB2.EventRegistration.Domain.Features.Event;

namespace IPB2.EventRegistrationMVC.Features.Event
{
    public class EventController : Controller
    {
        private readonly EventServices _eventServices;

        public EventController(EventServices eventServices)
        {
            _eventServices = eventServices;
        }

        public async Task<IActionResult> Index(int? pageNo, int? pageSize)
        {
            var request = new EventListRequest
            {
                PageNo = pageNo ?? 1,
                PageSize = pageSize ?? 10
            };
            var response = await _eventServices.GetEvents(request);
            return View(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var request = new EventGetByIdRequest { EventId = id };
            var response = await _eventServices.GetEventById(request);
            if (!response.IsSuccess)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _eventServices.CreateEvent(request);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message ?? "Error creating event.");
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var request = new EventGetByIdRequest { EventId = id };
            var response = await _eventServices.GetEventById(request);
            if (!response.IsSuccess)
            {
                return NotFound();
            }

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
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _eventServices.UpdateEvent(request);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message ?? "Error updating event.");
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var request = new EventGetByIdRequest { EventId = id };
            var response = await _eventServices.GetEventById(request);
            if (!response.IsSuccess)
            {
                return NotFound();
            }
            return View(response.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = new EventDeleteRequest { EventId = id };
            var response = await _eventServices.DeleteEvent(request);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            var getRequest = new EventGetByIdRequest { EventId = id };
            var eventResponse = await _eventServices.GetEventById(getRequest);
            
            ModelState.AddModelError("", response.Message ?? "Error deleting event.");
            return View(eventResponse.Data);
        }
    }
}
