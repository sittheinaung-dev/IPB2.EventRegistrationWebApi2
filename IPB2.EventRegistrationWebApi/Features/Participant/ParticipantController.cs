using Microsoft.AspNetCore.Mvc;

namespace IPB2.EventRegistrationWebApi.Features.Participant
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ParticipantServices _participantServices;

        public ParticipantController(ParticipantServices participantServices)
        {
            _participantServices = participantServices;
        }

        #region Create Participant
        [HttpPost("create")]
        public async Task<IActionResult> CreateParticipant([FromBody] ParticipantCreateRequest request)
        {
            var response = await _participantServices.CreateParticipant(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Update Participant
        [HttpPut("update")]
        public async Task<IActionResult> UpdateParticipant([FromBody] ParticipantUpdateRequest request)
        {
            var response = await _participantServices.UpdateParticipant(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Delete Participant
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var request = new ParticipantDeleteRequest { ParticipantId = id };
            var response = await _participantServices.DeleteParticipant(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Get Participant List
        [HttpGet("list")]
        public async Task<IActionResult> GetParticipants([FromQuery] int? pageNo, [FromQuery] int? pageSize)
        {
            var request = new ParticipantListRequest
            {
                PageNo = pageNo,
                PageSize = pageSize
            };
            var response = await _participantServices.GetParticipants(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Get Participant By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetParticipantById(int id)
        {
            var request = new ParticipantGetByIdRequest { ParticipantId = id };
            var response = await _participantServices.GetParticipantById(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion
    }
}