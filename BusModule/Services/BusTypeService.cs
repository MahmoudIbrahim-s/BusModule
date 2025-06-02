using AutoMapper;
using BusModule.DTOs;
using BusModule.Models;
using BusModule.Repositories;

namespace BusModule.Services
{
    public class BusTypeService : IBusTypeService
    {
        private readonly IGenericRepository<BusType> _repository;
        private readonly IMapper _mapper;

        public BusTypeService(IGenericRepository<BusType> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusTypeDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BusTypeDto>>(entities);
        }

        public async Task<BusTypeDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity is null ? null : _mapper.Map<BusTypeDto>(entity);
        }

        public async Task<BusTypeDto> CreateAsync(BusTypeDto dto)
        {
            var entity = _mapper.Map<BusType>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return _mapper.Map<BusTypeDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, BusTypeDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing is null) return false;

            _mapper.Map(dto, existing);
            _repository.Update(existing);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null) return false;

            _repository.Delete(entity);
            await _repository.SaveAsync();
            return true;
        }
    }

}
