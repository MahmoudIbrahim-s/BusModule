using AutoMapper;
using BusModule.DTOs;
using BusModule.Models;
using BusModule.Services;
using Microsoft.EntityFrameworkCore;

public class BusAssignmentService : IBusAssignmentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BusAssignmentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<bool> AssignStudentAsync(BusAssignmentDto dto)
    {
        var bus = await _context.Buses.FindAsync(dto.BusId);
        if (bus == null) return false;

        if (bus.IsCapacityRestricted)
        {
            int currentCount = await _context.BusAssignments
                .CountAsync(a => a.BusId == dto.BusId);

            if (currentCount >= bus.Capacity)
                return false; // Bus is full
        }

        bool alreadyAssigned = await _context.BusAssignments
            .AnyAsync(a => a.StudentId == dto.StudentId);

        if (alreadyAssigned) return false; 

        var assignment = new BusAssignment
        {
            StudentId = dto.StudentId,
            BusId = dto.BusId
        };

        await _context.BusAssignments.AddAsync(assignment);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> TransferStudentAsync(BusAssignmentDto dto)
    {
        var assignment = await _context.BusAssignments
            .FirstOrDefaultAsync(a => a.StudentId == dto.StudentId);

        if (assignment == null) return false;

        var newBus = await _context.Buses.FindAsync(dto.BusId);
        if (newBus == null) return false;

        if (newBus.IsCapacityRestricted)
        {
            int currentCount = await _context.BusAssignments
                .CountAsync(a => a.BusId == dto.BusId);

            if (currentCount >= newBus.Capacity)
                return false; // New bus is full
        }

        assignment.BusId = dto.BusId;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<BusDto?> GetStudentBusAsync(int studentId)
    {
        var assignment = await _context.BusAssignments
            .Include(a => a.Bus)
            .FirstOrDefaultAsync(a => a.StudentId == studentId);

        return assignment is null ? null : _mapper.Map<BusDto>(assignment.Bus);
    }
}
