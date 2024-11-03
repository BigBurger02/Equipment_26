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
        return Ok(await _db.Equipment.Include(x => x.Responsible).Include(x => x.Room)
            .Select(x => new Equipment()
            {
                Id = x.Id,
                Name = x.Name,
                Status = x.Status,
                Type = x.Type,
                IsOperational = x.IsOperational,
                PurchaseDate = x.PurchaseDate,
                SerialNumber = x.SerialNumber,
                WarrantyExpiry = x.WarrantyExpiry,
                LastMaintenanceDate = x.LastMaintenanceDate,
                RoomId = x.RoomId,
                Room = new Room()
                {
                    Id = x.Room.Id,
                    Capacity = x.Room.Capacity,
                    Name = x.Room.Name,
                    Type = x.Room.Type,
                    SectionId = x.Room.SectionId,
                },
                ResponsibleId = x.ResponsibleId,
                Responsible = x.Responsible,
            })
            .ToListAsync());
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
