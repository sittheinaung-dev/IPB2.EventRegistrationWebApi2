using Microsoft.AspNetCore.Mvc;

namespace IPB2.EventRegistrationWebApi.Features.Report
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportServices _reportServices;

        public ReportController(ReportServices reportServices)
        {
            _reportServices = reportServices;
        }

        #region Available Event List
        [HttpGet("available-events")]
        public async Task<IActionResult> GetAvailableEvents([FromQuery] int? pageNo, [FromQuery] int? pageSize)
        {
            var request = new AvailableEventsRequest
            {
                PageNo = pageNo,
                PageSize = pageSize
            };
            var response = await _reportServices.GetAvailableEvents(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Participants by Event
        [HttpGet("participants-by-event/{eventId}")]
        public async Task<IActionResult> GetParticipantsByEvent(int eventId)
        {
            var request = new ParticipantsByEventRequest
            {
                EventId = eventId
            };
            var response = await _reportServices.GetParticipantsByEvent(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion

        #region Search Events
        [HttpGet("search-events")]
        public async Task<IActionResult> SearchEvents([FromQuery] string searchTerm)
        {
            var request = new SearchEventsRequest
            {
                SearchTerm = searchTerm
            };
            var response = await _reportServices.SearchEvents(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        #endregion
    }
}