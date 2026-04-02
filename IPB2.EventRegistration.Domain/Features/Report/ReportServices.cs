using Microsoft.EntityFrameworkCore;
using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;
using IPB2.EventRegistration.Domain.Features.Event;
using IPB2.EventRegistration.Domain.Features.Participant;

namespace IPB2.EventRegistration.Domain.Features.Report
{
    public class ReportServices
    {
        private readonly AppDbContext _context;

        public ReportServices(AppDbContext context)
        {
            _context = context;
        }

        #region Get Available Events
        public async Task<AvailableEventsResponse> GetAvailableEvents(AvailableEventsRequest request)
        {
            try
            {
                var query = _context.Events.Where(x => x.IsDelete == false);

                int totalCount = await query.CountAsync();

                if (request.PageNo.HasValue && request.PageSize.HasValue)
                {
                    query = query.Skip((request.PageNo.Value - 1) * request.PageSize.Value)
                                 .Take(request.PageSize.Value);
                }

                var events = await query.ToListAsync();

                return new AvailableEventsResponse
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = events.Select(x => new EventResponse
                    {
                        EventId = x.EventId,
                        EventName = x.EventName ?? string.Empty,
                        Location = x.Location ?? string.Empty,
                        EventDate = x.EventDate,
                        Status = x.Status ?? string.Empty
                    }).ToList(),
                    TotalCount = totalCount,
                    PageNo = request.PageNo ?? 1,
                    PageSize = request.PageSize ?? totalCount
                };
            }
            catch (Exception ex)
            {
                return new AvailableEventsResponse { IsSuccess = false, Message = ex.Message };
            }
        }
        #endregion

        #region Get Participants By Event
        public async Task<ParticipantsByEventResponse> GetParticipantsByEvent(ParticipantsByEventRequest request)
        {
            try
            {
                var participants = await (from r in _context.Registrations
                                          join p in _context.Participants on r.ParticipantId equals p.ParticipantId
                                          where r.EventId == request.EventId && p.IsDelete == false
                                          select new ParticipantResponse
                                          {
                                              ParticipantId = p.ParticipantId,
                                              ParticipantName = p.ParticipantName,
                                              Email = p.Email,
                                              Phone = p.Phone
                                          }).ToListAsync();

                return new ParticipantsByEventResponse
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = participants
                };
            }
            catch (Exception ex)
            {
                return new ParticipantsByEventResponse { IsSuccess = false, Message = ex.Message };
            }
        }
        #endregion

        #region Search Events
        public async Task<SearchEventsResponse> SearchEvents(SearchEventsRequest request)
        {
            try
            {
                var query = _context.Events.Where(x => x.IsDelete == false);

                if (!string.IsNullOrEmpty(request.SearchTerm))
                {
                    query = query.Where(x => x.EventName != null && x.EventName.Contains(request.SearchTerm));
                }

                var events = await query.ToListAsync();

                return new SearchEventsResponse
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = events.Select(x => new EventResponse
                    {
                        EventId = x.EventId,
                        EventName = x.EventName ?? string.Empty,
                        Location = x.Location ?? string.Empty,
                        EventDate = x.EventDate,
                        Status = x.Status ?? string.Empty
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                return new SearchEventsResponse { IsSuccess = false, Message = ex.Message };
            }
        }
        #endregion

        public async Task<List<IPB2.EventRegistrationWebApi.Database.AppDbContextModels.Event>> GetActiveEvents()
        {
            return await _context.Events.Where(x => x.IsDelete == false).ToListAsync();
        }
    }
}
