using Microsoft.AspNetCore.Mvc;
using IPB2.EventRegistration.Domain.Features.Event;

namespace IPB2.EventRegistrationWebApi.Features.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly EventServices _eventServices;

        public EventController(EventServices eventServices)
        {
            _eventServices = eventServices;
        }

        #region Create Event
        [HttpPost("create")]
        public async Task<IActionResult> CreateEvent([FromBody] EventCreateRequest request)
        {
            var response = await _eventServices.CreateEvent(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Update Event
        [HttpPut("update")]
        public async Task<IActionResult> UpdateEvent([FromBody] EventUpdateRequest request)
        {
            var response = await _eventServices.UpdateEvent(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Delete Event
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var request = new EventDeleteRequest { EventId = id };
            var response = await _eventServices.DeleteEvent(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Get Event List
        [HttpGet("list")]
        public async Task<IActionResult> GetEvents([FromQuery] int? pageNo, [FromQuery] int? pageSize)
        {
            var request = new EventListRequest
            {
                PageNo = pageNo,
                PageSize = pageSize
            };
            var response = await _eventServices.GetEvents(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Get Event By Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(int id)
        {
            var request = new EventGetByIdRequest { EventId = id };
            var response = await _eventServices.GetEventById(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion
    }
}
