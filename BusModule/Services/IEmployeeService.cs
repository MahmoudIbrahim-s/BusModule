using BusModule.DTOs;

namespace BusModule.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeDto> CreateAsync(EmployeeDto dto, string password);
        Task<bool> UpdateAsync(int id, EmployeeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
