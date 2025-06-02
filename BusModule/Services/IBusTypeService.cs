using BusModule.DTOs;

namespace BusModule.Services
{
    public interface IBusTypeService
    {
        Task<IEnumerable<BusTypeDto>> GetAllAsync();
        Task<BusTypeDto?> GetByIdAsync(int id);
        Task<BusTypeDto> CreateAsync(BusTypeDto dto);
        Task<bool> UpdateAsync(int id, BusTypeDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
