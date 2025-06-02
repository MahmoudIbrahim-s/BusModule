using BusModule.DTOs;

namespace BusModule.Services
{
    public interface IBusService
    {
        Task<IEnumerable<BusDto>> GetAllAsync();
        Task<BusDto?> GetByIdAsync(int id);
        Task<BusDto> CreateAsync(BusDto dto);
        Task<bool> UpdateAsync(int id, BusDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
