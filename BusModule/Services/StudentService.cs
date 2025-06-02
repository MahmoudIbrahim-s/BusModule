using AutoMapper;
using BusModule.DTOs;
using BusModule.Models;
using BusModule.Repositories;

namespace BusModule.Services
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _repository;
        private readonly IMapper _mapper;

        public StudentService(IGenericRepository<Student> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDto>>(students);
        }

        public async Task<StudentDto?> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            return student == null ? null : _mapper.Map<StudentDto>(student);
        }

        public async Task<StudentDto> CreateAsync(StudentDto dto)
        {
            var entity = _mapper.Map<Student>(dto);
            await _repository.AddAsync(entity);
            await _repository.SaveAsync();
            return _mapper.Map<StudentDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, StudentDto dto)
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
            var student = await _repository.GetByIdAsync(id);
            if (student == null) return false;

            _repository.Delete(student);
            await _repository.SaveAsync();
            return true;
        }
    }
}
