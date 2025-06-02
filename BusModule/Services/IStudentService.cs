using BusModule.DTOs;

namespace BusModule.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task<StudentDto?> GetByIdAsync(int id);
        Task<StudentDto> CreateAsync(StudentDto dto);
        Task<bool> UpdateAsync(int id, StudentDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
