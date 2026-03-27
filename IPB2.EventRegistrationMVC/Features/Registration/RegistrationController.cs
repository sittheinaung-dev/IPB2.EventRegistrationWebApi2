using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IPB2.EventRegistrationMVC.Features.Registration
{
    public class RegistrationController : Controller
    {
        private readonly RegistrationServices _registrationServices;

        public RegistrationController(RegistrationServices registrationServices)
        {
            _registrationServices = registrationServices;
        }

        public async Task<IActionResult> Index(int? eventId)
        {
            var request = new RegistrationListRequest { EventId = eventId };
            var response = await _registrationServices.GetRegistrations(request);
            
            ViewBag.Events = new SelectList(await _registrationServices.GetActiveEvents(), "EventId", "EventName", eventId);
            
            return View(response);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Events = new SelectList(await _registrationServices.GetActiveEvents(), "EventId", "EventName");
            ViewBag.Participants = new SelectList(await _registrationServices.GetActiveParticipants(), "ParticipantId", "ParticipantName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistrationCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Events = new SelectList(await _registrationServices.GetActiveEvents(), "EventId", "EventName", request.EventId);
                ViewBag.Participants = new SelectList(await _registrationServices.GetActiveParticipants(), "ParticipantId", "ParticipantName", request.ParticipantId);
                return View(request);
            }

            var response = await _registrationServices.RegisterParticipant(request);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message ?? "Error creating registration.");
            ViewBag.Events = new SelectList(await _registrationServices.GetActiveEvents(), "EventId", "EventName", request.EventId);
            ViewBag.Participants = new SelectList(await _registrationServices.GetActiveParticipants(), "ParticipantId", "ParticipantName", request.ParticipantId);
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var registrations = await _registrationServices.GetRegistrations(new RegistrationListRequest());
            var registration = registrations.Data?.FirstOrDefault(x => x.RegistrationId == id);
            
            if (registration == null)
            {
                return NotFound();
            }

            var request = new RegistrationUpdateRequest
            {
                RegistrationId = registration.RegistrationId,
                Status = registration.Status
            };

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RegistrationUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _registrationServices.UpdateRegistration(request);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message ?? "Error updating registration.");
            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            var request = new RegistrationCancelRequest { RegistrationId = id };
            var response = await _registrationServices.CancelRegistration(request);
            return RedirectToAction(nameof(Index));
        }
    }
}
