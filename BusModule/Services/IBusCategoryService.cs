using BusModule.DTOs;

namespace BusModule.Services
{
    public interface IBusCategoryService
    {
        Task<IEnumerable<BusCategoryDto>> GetAllAsync();
        Task<BusCategoryDto?> GetByIdAsync(int id);
        Task<BusCategoryDto> CreateAsync(BusCategoryDto dto);
        Task<bool> UpdateAsync(int id, BusCategoryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
