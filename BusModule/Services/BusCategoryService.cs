using AutoMapper;
using BusModule.DTOs;
using BusModule.Models;
using BusModule.Repositories;
using BusModule.Services;

public class BusCategoryService : IBusCategoryService
{
    private readonly IGenericRepository<BusCategory> _repository;
    private readonly IMapper _mapper;

    public BusCategoryService(IGenericRepository<BusCategory> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BusCategoryDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<BusCategoryDto>>(entities);
    }

    public async Task<BusCategoryDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity is null ? null : _mapper.Map<BusCategoryDto>(entity);
    }

    public async Task<BusCategoryDto> CreateAsync(BusCategoryDto dto)
    {
        var entity = _mapper.Map<BusCategory>(dto);
        await _repository.AddAsync(entity);
        await _repository.SaveAsync();
        return _mapper.Map<BusCategoryDto>(entity);
    }

    public async Task<bool> UpdateAsync(int id, BusCategoryDto dto)
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
