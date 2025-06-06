using BusModule.DTOs;
using BusModule.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BusAssignmentController : ControllerBase
{
    private readonly IBusAssignmentService _service;

    public BusAssignmentController(IBusAssignmentService service)
    {
        _service = service;
    }
    [Authorize(Roles = "Admin")]

    [HttpPost("assign")]
    public async Task<IActionResult> AssignStudent([FromBody] BusAssignmentDto dto)
    {
        var result = await _service.AssignStudentAsync(dto);
        if (!result)
            return BadRequest("Assignment failed: Check capacity or duplicate assignment.");
        return Ok("Student assigned successfully.");
    }
    [Authorize(Roles = "Admin")]
    [HttpPost("transfer")]
    public async Task<IActionResult> TransferStudent([FromBody] BusAssignmentDto dto)
    {
        var result = await _service.TransferStudentAsync(dto);
        if (!result)
            return BadRequest("Transfer failed: Bus may be full or student not assigned.");
        return Ok("Student transferred successfully.");
    }
    [Authorize(Roles = "Admin,Student")]

    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetStudentBus(int studentId)
    {
        var result = await _service.GetStudentBusAsync(studentId);
        if (result == null) return NotFound("Student not assigned to any bus.");
        return Ok(result);
    }
}
