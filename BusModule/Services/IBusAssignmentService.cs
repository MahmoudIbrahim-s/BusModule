using BusModule.DTOs;

namespace BusModule.Services
{
    public interface IBusAssignmentService
    {
        Task<bool> AssignStudentAsync(BusAssignmentDto dto);
        Task<bool> TransferStudentAsync(BusAssignmentDto dto);
        Task<BusDto?> GetStudentBusAsync(int studentId);
    }
}
