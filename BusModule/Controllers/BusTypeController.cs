using BusModule.DTOs;
using BusModule.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BusTypeController : ControllerBase
{
    private readonly IBusTypeService _busTypeService;

    public BusTypeController(IBusTypeService busTypeService)
    {
        _busTypeService = busTypeService;
    }

    // GET: api/BusType
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _busTypeService.GetAllAsync();
        return Ok(result);
    }

    // GET: api/BusType/id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _busTypeService.GetByIdAsync(id);
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    // POST: api/BusType
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] BusTypeDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var created = await _busTypeService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    // PUT: api/BusType/id
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] BusTypeDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = await _busTypeService.UpdateAsync(id, dto);
        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/BusType/id
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _busTypeService.DeleteAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
