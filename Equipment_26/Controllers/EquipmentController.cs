using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equipment_26.Data;
using Equipment_26.Model;

namespace Equipment_26.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EquipmentController : ControllerBase
{
    private readonly AppDbContext _db;

    public EquipmentController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Equipment>>> GetEquipment()
    {
        return Ok(await _db.Equipment.ToListAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Equipment>> GetEquipment(int id)
    {
        var equipment = await _db.Equipment.FindAsync(id);

        if (equipment == null)
        {
            return NotFound();
        }

        return equipment;
    }
    
    [HttpPut]
    public async Task<IActionResult> PutEquipment(Equipment equipment)
    {
        _db.Entry(equipment).State = EntityState.Modified;
        
        await _db.SaveChangesAsync();

        return Ok(equipment);
    }
    
    [HttpPost]
    public async Task<ActionResult<Equipment>> PostEquipment(Equipment equipment)
    {
        _db.Equipment.Add(equipment);
        await _db.SaveChangesAsync();

        return Created("", equipment);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEquipment(int id)
    {
        var equipment = await _db.Equipment.FindAsync(id);
        if (equipment == null)
        {
            return NotFound();
        }

        _db.Equipment.Remove(equipment);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
