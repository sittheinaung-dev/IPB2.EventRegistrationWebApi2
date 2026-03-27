using Microsoft.AspNetCore.Mvc;

namespace IPB2.EventRegistrationMVC.Features.Participant
{
    public class ParticipantController : Controller
    {
        private readonly ParticipantServices _participantServices;

        public ParticipantController(ParticipantServices participantServices)
        {
            _participantServices = participantServices;
        }

        public async Task<IActionResult> Index(int? pageNo, int? pageSize)
        {
            var request = new ParticipantListRequest
            {
                PageNo = pageNo ?? 1,
                PageSize = pageSize ?? 10
            };
            var response = await _participantServices.GetParticipants(request);
            return View(response);
        }

        public async Task<IActionResult> Details(int id)
        {
            var request = new ParticipantGetByIdRequest { ParticipantId = id };
            var response = await _participantServices.GetParticipantById(request);
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
        public async Task<IActionResult> Create(ParticipantCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _participantServices.CreateParticipant(request);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message ?? "Error creating participant.");
            return View(request);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var request = new ParticipantGetByIdRequest { ParticipantId = id };
            var response = await _participantServices.GetParticipantById(request);
            if (!response.IsSuccess)
            {
                return NotFound();
            }

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
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await _participantServices.UpdateParticipant(request);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", response.Message ?? "Error updating participant.");
            return View(request);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var request = new ParticipantGetByIdRequest { ParticipantId = id };
            var response = await _participantServices.GetParticipantById(request);
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
            var request = new ParticipantDeleteRequest { ParticipantId = id };
            var response = await _participantServices.DeleteParticipant(request);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }

            var getRequest = new ParticipantGetByIdRequest { ParticipantId = id };
            var participantResponse = await _participantServices.GetParticipantById(getRequest);
            
            ModelState.AddModelError("", response.Message ?? "Error deleting participant.");
            return View(participantResponse.Data);
        }
    }
}
