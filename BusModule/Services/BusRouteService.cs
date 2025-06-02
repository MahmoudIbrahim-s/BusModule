using AutoMapper;
using BusModule.DTOs;
using BusModule.Models;
using BusModule.Repositories;

namespace BusModule.Services
{
    public class BusRouteService : IBusRouteService
    {
        private readonly IGenericRepository<BusRoute> _repository;
        private readonly IMapper _mapper;

        public BusRouteService(IGenericRepository<BusRoute> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BusRouteDto>> GetAllAsync()
        {
            var routes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BusRouteDto>>(routes);
        }

        public async Task<BusRouteDto?> GetByIdAsync(int id)
        {
            var route = await _repository.GetByIdAsync(id);
            return route is null ? null : _mapper.Map<BusRouteDto>(route);
        }

        public async Task<BusRouteDto> CreateAsync(BusRouteDto dto)
        {
            var entity = _mapper.Map<BusRoute>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return _mapper.Map<BusRouteDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, BusRouteDto dto)
        {
            var route = await _repository.GetByIdAsync(id);
            if (route == null) return false;

            _mapper.Map(dto, route);
            _repository.Update(route);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var route = await _repository.GetByIdAsync(id);
            if (route == null) return false;

            _repository.Delete(route);
            await _repository.SaveAsync();
            return true;
        }

    }
}
