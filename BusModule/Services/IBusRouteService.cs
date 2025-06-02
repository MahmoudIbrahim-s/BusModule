using BusModule.DTOs;

namespace BusModule.Services
{
    public interface IBusRouteService
    {
        Task<IEnumerable<BusRouteDto>> GetAllAsync();
        Task<BusRouteDto?> GetByIdAsync(int id);
        Task<BusRouteDto> CreateAsync(BusRouteDto dto);
        Task<bool> UpdateAsync(int id, BusRouteDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
