using AutoMapper;
using BusModule.DTOs;
using BusModule.Models;
using BusModule.Repositories;

namespace BusModule.Services
{
    public class BusService : IBusService
    {
        private readonly IGenericRepository<Bus> _repository;
        private readonly IMapper _mapper;

        public BusService(IGenericRepository<Bus> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusDto>> GetAllAsync()
        {
            var buses = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BusDto>>(buses);
        }

        public async Task<BusDto?> GetByIdAsync(int id)
        {
            var bus = await _repository.GetByIdAsync(id);
            return bus is null ? null : _mapper.Map<BusDto>(bus);
        }

        public async Task<BusDto> CreateAsync(BusDto dto)
        {
            var bus = _mapper.Map<Bus>(dto);
            await _repository.AddAsync(bus);
            await _repository.SaveAsync();
            return _mapper.Map<BusDto>(bus);
        }

        public async Task<bool> UpdateAsync(int id, BusDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            _repository.Update(existing);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bus = await _repository.GetByIdAsync(id);
            if (bus == null) return false;

            _repository.Delete(bus);
            await _repository.SaveAsync();
            return true;
        }
    }
}
