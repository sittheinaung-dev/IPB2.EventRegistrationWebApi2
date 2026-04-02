using Microsoft.EntityFrameworkCore;
using IPB2.EventRegistrationWebApi.Database.AppDbContextModels;

namespace IPB2.EventRegistration.Domain.Features.Participant
{
    public class ParticipantServices
    {
        private readonly AppDbContext _context;

        public ParticipantServices(AppDbContext context)
        {
            _context = context;
        }

        #region Create Participant
        public async Task<ParticipantCreateResponse> CreateParticipant(ParticipantCreateRequest request)
        {
            try
            {
                var existingParticipant = await _context.Participants
                    .FirstOrDefaultAsync(x => x.Email == request.Email && x.IsDelete == false);

                if (existingParticipant != null)
                {
                    return new ParticipantCreateResponse
                    {
                        IsSuccess = false,
                        Message = "Email already exists."
                    };
                }

                var participantEntity = new IPB2.EventRegistrationWebApi.Database.AppDbContextModels.Participant
                {
                    ParticipantName = request.ParticipantName,
                    Email = request.Email,
                    Phone = request.Phone,
                    IsDelete = false
                };

                await _context.Participants.AddAsync(participantEntity);
                await _context.SaveChangesAsync();

                var response = new ParticipantCreateResponse
                {
                    IsSuccess = true,
                    Message = "Participant created successfully.",
                    Data = new ParticipantResponse
                    {
                        ParticipantId = participantEntity.ParticipantId,
                        ParticipantName = participantEntity.ParticipantName,
                        Email = participantEntity.Email,
                        Phone = participantEntity.Phone
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return new ParticipantCreateResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Update Participant
        public async Task<ParticipantUpdateResponse> UpdateParticipant(ParticipantUpdateRequest request)
        {
            try
            {
                var participantEntity = await _context.Participants
                    .FirstOrDefaultAsync(x => x.ParticipantId == request.ParticipantId && x.IsDelete == false);

                if (participantEntity is null)
                {
                    return new ParticipantUpdateResponse
                    {
                        IsSuccess = false,
                        Message = "Participant not found."
                    };
                }

                if (participantEntity.Email != request.Email)
                {
                    var existingEmail = await _context.Participants
                        .FirstOrDefaultAsync(x => x.Email == request.Email && x.IsDelete == false);

                    if (existingEmail != null)
                    {
                        return new ParticipantUpdateResponse
                        {
                            IsSuccess = false,
                            Message = "Email already exists."
                        };
                    }
                }

                participantEntity.ParticipantName = request.ParticipantName;
                participantEntity.Email = request.Email;
                participantEntity.Phone = request.Phone;

                await _context.SaveChangesAsync();

                var response = new ParticipantUpdateResponse
                {
                    IsSuccess = true,
                    Message = "Participant updated successfully.",
                    Data = new ParticipantResponse
                    {
                        ParticipantId = participantEntity.ParticipantId,
                        ParticipantName = participantEntity.ParticipantName,
                        Email = participantEntity.Email,
                        Phone = participantEntity.Phone
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return new ParticipantUpdateResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Delete Participant
        public async Task<ParticipantDeleteResponse> DeleteParticipant(ParticipantDeleteRequest request)
        {
            try
            {
                var participantEntity = await _context.Participants
                    .FirstOrDefaultAsync(x => x.ParticipantId == request.ParticipantId && x.IsDelete == false);

                if (participantEntity is null)
                {
                    return new ParticipantDeleteResponse
                    {
                        IsSuccess = false,
                        Message = "Participant not found."
                    };
                }

                var hasRegistrations = await _context.Registrations
                    .AnyAsync(x => x.ParticipantId == request.ParticipantId && x.Status == "Confirmed");

                if (hasRegistrations)
                {
                    return new ParticipantDeleteResponse
                    {
                        IsSuccess = false,
                        Message = "Cannot delete participant with active registrations."
                    };
                }

                participantEntity.IsDelete = true;
                await _context.SaveChangesAsync();

                return new ParticipantDeleteResponse
                {
                    IsSuccess = true,
                    Message = "Participant deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new ParticipantDeleteResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Get Participant List
        public async Task<ParticipantListResponse> GetParticipants(ParticipantListRequest request)
        {
            try
            {
                var query = _context.Participants
                    .Where(x => x.IsDelete == false)
                    .OrderBy(x => x.ParticipantId);

                int totalCount = await query.CountAsync();

                if (request.PageNo.HasValue && request.PageSize.HasValue)
                {
                    query = query.Skip((request.PageNo.Value - 1) * request.PageSize.Value)
                                 .OrderBy(x => x.ParticipantId);
                }

                var participants = await query.ToListAsync();

                var response = new ParticipantListResponse
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = participants.Select(x => new ParticipantResponse
                    {
                        ParticipantId = x.ParticipantId,
                        ParticipantName = x.ParticipantName,
                        Email = x.Email,
                        Phone = x.Phone
                    }).ToList(),
                    PageNo = request.PageNo ?? 1,
                    PageSize = request.PageSize ?? totalCount,
                    TotalCount = totalCount
                };

                return response;
            }
            catch (Exception ex)
            {
                return new ParticipantListResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion

        #region Get Participant By Id
        public async Task<ParticipantGetByIdResponse> GetParticipantById(ParticipantGetByIdRequest request)
        {
            try
            {
                var participantEntity = await _context.Participants
                    .FirstOrDefaultAsync(x => x.ParticipantId == request.ParticipantId && x.IsDelete == false);

                if (participantEntity is null)
                {
                    return new ParticipantGetByIdResponse
                    {
                        IsSuccess = false,
                        Message = "Participant not found."
                    };
                }

                var response = new ParticipantGetByIdResponse
                {
                    IsSuccess = true,
                    Message = "Success",
                    Data = new ParticipantResponse
                    {
                        ParticipantId = participantEntity.ParticipantId,
                        ParticipantName = participantEntity.ParticipantName,
                        Email = participantEntity.Email,
                        Phone = participantEntity.Phone
                    }
                };

                return response;
            }
            catch (Exception ex)
            {
                return new ParticipantGetByIdResponse
                {
                    IsSuccess = false,
                    Message = $"Error: {ex.Message}"
                };
            }
        }
        #endregion
    }
}
