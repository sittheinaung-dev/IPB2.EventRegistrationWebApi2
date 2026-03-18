using Microsoft.EntityFrameworkCore;
using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;

namespace IPB2.EventRegistrationWebApi.Features.Event
{
    public class EventServices
    {
        private readonly AppDbContext _context;

        public EventServices(AppDbContext context)
        {
            _context = context;
        }

        #region Create Event
        public async Task<EventCreateResponse> CreateEvent(EventCreateRequest request)
        {
            try
            {
                var eventEntity = new Database.AppDbContextModels.Event
                {
                    EventName = request.EventName,
                    Location = request.Location,
                    EventDate = request.EventDate,
                    Status = request.Status ?? "Active",
                    IsDelete = false
                };

                await _context.Events.AddAsync(eventEntity);
                await _context.SaveChangesAsync();

                var response = new EventCreateResponse
                {
                    IsSuccess = true,
                    Message = "Event created successfully.",
                    Data = new EventResponse
                    {
                        EventId = eventEntity.EventId,
                        EventName = eventEntity.EventName,
                        Location = eventEntity.Location,
                        EventDate = eventEntity.EventDate,
                        Status = eventEntity.Status
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return new EventCreateResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Update Event
        public async Task<EventUpdateResponse> UpdateEvent(EventUpdateRequest request)
        {
            try
            {
                var eventEntity = await _context.Events
                    .FirstOrDefaultAsync(x => x.EventId == request.EventId && x.IsDelete == false);

                if (eventEntity is null)
                {
                    return new EventUpdateResponse
                    {
                        IsSuccess = false,
                        Message = "Event not found."
                    };
                }

                eventEntity.EventName = request.EventName;
                eventEntity.Location = request.Location;
                eventEntity.EventDate = request.EventDate;
                eventEntity.Status = request.Status;

                await _context.SaveChangesAsync();

                var response = new EventUpdateResponse
                {
                    IsSuccess = true,
                    Message = "Event updated successfully.",
                    Data = new EventResponse
                    {
                        EventId = eventEntity.EventId,
                        EventName = eventEntity.EventName,
                        Location = eventEntity.Location,
                        EventDate = eventEntity.EventDate,
                        Status = eventEntity.Status
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return new EventUpdateResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Delete Event
        public async Task<EventDeleteResponse> DeleteEvent(EventDeleteRequest request)
        {
            try
            {
                var eventEntity = await _context.Events
                    .FirstOrDefaultAsync(x => x.EventId == request.EventId && x.IsDelete == false);

                if (eventEntity is null)
                {
                    return new EventDeleteResponse
                    {
                        IsSuccess = false,
                        Message = "Event not found."
                    };
                }

                // Check if event has active registrations
                var hasRegistrations = await _context.Registrations
                    .AnyAsync(x => x.EventId == request.EventId && x.Status == "Confirmed");

                if (hasRegistrations)
                {
                    return new EventDeleteResponse
                    {
                        IsSuccess = false,
                        Message = "Cannot delete event with active registrations."
                    };
                }

                eventEntity.IsDelete = true;
                await _context.SaveChangesAsync();

                return new EventDeleteResponse
                {
                    IsSuccess = true,
                    Message = "Event deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new EventDeleteResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Get Event List
        public async Task<EventListResponse> GetEvents(EventListRequest request)
        {
            try
            {
                IQueryable<Database.AppDbContextModels.Event> query = _context.Events
                    .Where(x => x.IsDelete == false)
                    .OrderBy(x => x.EventId);

                int totalCount = await query.CountAsync();

                if (request.PageNo.HasValue && request.PageSize.HasValue)
                {
                    query = query.Skip((request.PageNo.Value - 1) * request.PageSize.Value)
                                 .Take(request.PageSize.Value);
                }

                var events = await query.ToListAsync();

                var response = new EventListResponse
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = events.Select(x => new EventResponse
                    {
                        EventId = x.EventId,
                        EventName = x.EventName,
                        Location = x.Location,
                        EventDate = x.EventDate,
                        Status = x.Status
                    }).ToList(),
                    PageNo = request.PageNo ?? 1,
                    PageSize = request.PageSize ?? totalCount,
                    TotalCount = totalCount
                };

                return response;
            }
            catch (Exception ex)
            {
                return new EventListResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Get Event By Id
        public async Task<EventGetByIdResponse> GetEventById(EventGetByIdRequest request)
        {
            try
            {
                var eventEntity = await _context.Events
                    .FirstOrDefaultAsync(x => x.EventId == request.EventId && x.IsDelete == false);

                if (eventEntity is null)
                {
                    return new EventGetByIdResponse
                    {
                        IsSuccess = false,
                        Message = "Event not found."
                    };
                }

                var response = new EventGetByIdResponse
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = new EventResponse
                    {
                        EventId = eventEntity.EventId,
                        EventName = eventEntity.EventName,
                        Location = eventEntity.Location,
                        EventDate = eventEntity.EventDate,
                        Status = eventEntity.Status
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return new EventGetByIdResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion
    }
}