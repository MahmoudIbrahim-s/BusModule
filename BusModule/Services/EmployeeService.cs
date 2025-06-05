using AutoMapper;
using BusModule.DTOs;
using BusModule.Repositories;

namespace BusModule.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IMapper _mapper;
        public EmployeeService(IGenericRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            return employee == null ? null : _mapper.Map<EmployeeDto>(employee);
        }
        public async Task<EmployeeDto> CreateAsync(EmployeeDto dto)
        {
            var employee = _mapper.Map<Employee>(dto);
           
            await _repository.AddAsync(employee);
            await _repository.SaveAsync();
            return _mapper.Map<EmployeeDto>(employee);
        }
        public async Task<bool> UpdateAsync(int id, EmployeeDto dto)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return false;
            
            _mapper.Map(dto, employee);
            _repository.Update(employee);
            await _repository.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            if (employee == null) return false;
            
            _repository.Delete(employee);
            await _repository.SaveAsync();
            return true;
        }

    }
}
