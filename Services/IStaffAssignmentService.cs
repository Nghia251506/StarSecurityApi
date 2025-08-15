using StarSecurityApi.Dtos.StaffAssignment;

namespace StarSecurityApi.Services
{
    public interface IStaffAssignmentService
    {
        Task<IEnumerable<StaffAssignmentReadDto>> GetAllAsync();
        Task<StaffAssignmentReadDto?> GetByIdAsync(int id);
        Task<StaffAssignmentReadDto> CreateAsync(StaffAssignmentCreateDto dto);
        Task<bool> UpdateAsync(int id, StaffAssignmentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
