using Microsoft.EntityFrameworkCore;
using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;

namespace IPB2.EventRegistrationWebApi.Features.Registration
{
    public class RegistrationServices
    {
        private readonly AppDbContext _context;

        public RegistrationServices(AppDbContext context)
        {
            _context = context;
        }

        #region Register Participant
        public async Task<RegistrationCreateResponse> RegisterParticipant(RegistrationCreateRequest request)
        {
            try
            {
                // Check if event exists and is active
                var eventEntity = await _context.Events
                    .FirstOrDefaultAsync(x => x.EventId == request.EventId && x.IsDelete == false);

                if (eventEntity is null)
                {
                    return new RegistrationCreateResponse
                    {
                        IsSuccess = false,
                        Message = "Event not found."
                    };
                }

                // Check if participant exists
                var participantEntity = await _context.Participants
                    .FirstOrDefaultAsync(x => x.ParticipantId == request.ParticipantId && x.IsDelete == false);

                if (participantEntity is null)
                {
                    return new RegistrationCreateResponse
                    {
                        IsSuccess = false,
                        Message = "Participant not found."
                    };
                }

                // Check if already registered
                var existingRegistration = await _context.Registrations
                    .FirstOrDefaultAsync(x => x.EventId == request.EventId &&
                                             x.ParticipantId == request.ParticipantId);

                if (existingRegistration != null)
                {
                    return new RegistrationCreateResponse
                    {
                        IsSuccess = false,
                        Message = "Participant already registered for this event."
                    };
                }

                var registrationEntity = new Database.AppDbContextModels.Registration
                {
                    EventId = request.EventId,
                    ParticipantId = request.ParticipantId,
                    RegisterDate = DateOnly.FromDateTime(DateTime.Now),
                    Status = "Confirmed"
                };

                await _context.Registrations.AddAsync(registrationEntity);
                await _context.SaveChangesAsync();

                // Load navigation properties for response
                if (registrationEntity == null)
                {
                    return new RegistrationCreateResponse
                    {
                        IsSuccess = false,
                        Message = "Failed to retrieve the created registration."
                    };
                }

                var eventName = await _context.Events
                    .Where(x => x.EventId == registrationEntity.EventId)
                    .Select(x => x.EventName)
                    .FirstOrDefaultAsync();

                var participantName = await _context.Participants
                    .Where(x => x.ParticipantId == registrationEntity.ParticipantId)
                    .Select(x => x.ParticipantName)
                    .FirstOrDefaultAsync();

                var response = new RegistrationCreateResponse
                {
                    IsSuccess = true,
                    Message = "Registration successful.",
                    Data = new RegistrationResponse
                    {
                        RegistrationId = registrationEntity.RegistrationId,
                        EventId = registrationEntity.EventId ?? 0,
                        EventName = eventName ?? "",
                        ParticipantId = registrationEntity.ParticipantId ?? 0,
                        ParticipantName = participantName ?? "",
                        RegisterDate = registrationEntity.RegisterDate.HasValue ? registrationEntity.RegisterDate.Value.ToDateTime(TimeOnly.MinValue) : DateTime.MinValue,
                        Status = registrationEntity.Status ?? ""
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return new RegistrationCreateResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Update Registration
        public async Task<RegistrationUpdateResponse> UpdateRegistration(RegistrationUpdateRequest request)
        {
            try
            {
                var registrationEntity = await _context.Registrations
                    .FirstOrDefaultAsync(x => x.RegistrationId == request.RegistrationId);

                if (registrationEntity is null)
                {
                    return new RegistrationUpdateResponse
                    {
                        IsSuccess = false,
                        Message = "Registration not found."
                    };
                }

                if (request.Status != "Confirmed" && request.Status != "Cancelled" && 
                    request.Status != "Confirm" && request.Status != "Cancel")
                {
                    return new RegistrationUpdateResponse
                    {
                        IsSuccess = false,
                        Message = "Invalid status. Only 'Confirm' or 'Cancel' are allowed."
                    };
                }

                // Map "Confirm" to "Confirmed" and "Cancel" to "Cancelled" if needed
                string finalStatus = request.Status;
                if (request.Status == "Confirm") finalStatus = "Confirmed";
                if (request.Status == "Cancel") finalStatus = "Cancelled";

                registrationEntity.Status = finalStatus;
                await _context.SaveChangesAsync();

                if (registrationEntity == null)
                {
                    return new RegistrationUpdateResponse
                    {
                        IsSuccess = false,
                        Message = "Registration not found."
                    };
                }

                var eventName = await _context.Events
                    .Where(x => x.EventId == registrationEntity.EventId)
                    .Select(x => x.EventName)
                    .FirstOrDefaultAsync();
                var participantName = await _context.Participants
                    .Where(x => x.ParticipantId == registrationEntity.ParticipantId)
                    .Select(x => x.ParticipantName)
                    .FirstOrDefaultAsync();

                var response = new RegistrationUpdateResponse
                {
                    IsSuccess = true,
                    Message = "Registration updated successfully.",
                    Data = new RegistrationResponse
                    {
                        RegistrationId = registrationEntity.RegistrationId,
                        EventId = registrationEntity.EventId ?? 0,
                        EventName = eventName ?? "",
                        ParticipantId = registrationEntity.ParticipantId ?? 0,
                        ParticipantName = participantName ?? "",
                        RegisterDate = registrationEntity.RegisterDate.HasValue ? registrationEntity.RegisterDate.Value.ToDateTime(TimeOnly.MinValue) : DateTime.MinValue,
                        Status = registrationEntity.Status ?? ""
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return new RegistrationUpdateResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Cancel Registration
        public async Task<RegistrationCancelResponse> CancelRegistration(RegistrationCancelRequest request)
        {
            try
            {
                var registrationEntity = await _context.Registrations
                    .FirstOrDefaultAsync(x => x.RegistrationId == request.RegistrationId);

                if (registrationEntity is null)
                {
                    return new RegistrationCancelResponse
                    {
                        IsSuccess = false,
                        Message = "Registration not found."
                    };
                }

                registrationEntity.Status = "Cancelled";
                await _context.SaveChangesAsync();

                return new RegistrationCancelResponse
                {
                    IsSuccess = true,
                    Message = "Registration cancelled successfully."
                };
            }
            catch (Exception ex)
            {
                return new RegistrationCancelResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Get Registrations
        public async Task<RegistrationListResponse> GetRegistrations(RegistrationListRequest request)
        {
            try
            {
                var query = from r in _context.Registrations
                            join e in _context.Events on r.EventId equals e.EventId
                            join p in _context.Participants on r.ParticipantId equals p.ParticipantId
                            where e.IsDelete == false && p.IsDelete == false
                            select new { r, e, p };

                if (request.EventId.HasValue)
                {
                    query = query.Where(x => x.r.EventId == request.EventId);
                }

                var registrations = await query
                    .OrderByDescending(x => x.r.RegisterDate)
                    .ToListAsync();

                var response = new RegistrationListResponse
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = registrations.Select(x => new RegistrationResponse
                    {
                        RegistrationId = x.r.RegistrationId,
                        EventId = x.r.EventId ?? 0,
                        EventName = x.e.EventName ?? "",
                        ParticipantId = x.r.ParticipantId ?? 0,
                        ParticipantName = x.p.ParticipantName ?? "",
                        RegisterDate = x.r.RegisterDate.HasValue ? x.r.RegisterDate.Value.ToDateTime(TimeOnly.MinValue) : DateTime.MinValue,
                        Status = x.r.Status ?? ""
                    }).ToList(),
                    TotalCount = registrations.Count
                };

                return response;
            }
            catch (Exception ex)
            {
                return new RegistrationListResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion
    }
}