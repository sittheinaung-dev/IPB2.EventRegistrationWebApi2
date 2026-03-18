using Microsoft.AspNetCore.Mvc;

namespace IPB2.EventRegistrationWebApi.Features.Registration
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly RegistrationServices _registrationServices;

        public RegistrationController(RegistrationServices registrationServices)
        {
            _registrationServices = registrationServices;
        }

        #region Register Participant
        [HttpPost("register")]
        public async Task<IActionResult> RegisterParticipant([FromBody] RegistrationCreateRequest request)
        {
            var response = await _registrationServices.RegisterParticipant(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Update Registration
        [HttpPut("update")]
        public async Task<IActionResult> UpdateRegistration([FromBody] RegistrationUpdateRequest request)
        {
            var response = await _registrationServices.UpdateRegistration(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Cancel Registration
        [HttpPut("cancel/{id}")]
        public async Task<IActionResult> CancelRegistration(int id)
        {
            var request = new RegistrationCancelRequest { RegistrationId = id };
            var response = await _registrationServices.CancelRegistration(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Get Registrations
        [HttpGet("list")]
        public async Task<IActionResult> GetRegistrations([FromQuery] int? eventId)
        {
            var request = new RegistrationListRequest
            {
                EventId = eventId
            };
            var response = await _registrationServices.GetRegistrations(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion
    }
}