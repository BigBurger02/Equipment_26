using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equipment_26.Data;
using Equipment_26.Model;

namespace Equipment_26.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    private readonly AppDbContext _db;

    public RoomController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Room>>> GetRooms()
    {
        return Ok(await _db.Rooms.Include(x => x.Section)
            .Select(y => new Room
            {
                Id = y.Id,
                Capacity = y.Capacity,
                Name = y.Name,
                Type = y.Type,
                SectionId = y.SectionId,
                Section = new Section()
                {
                    Id = y.Section.Id,
                    Name = y.Section.Name,
                    FlourCount = y.Section.FlourCount,
                }
            })
            .ToListAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> GetRoom(int id)
    {
        var room = await _db.Rooms.FindAsync(id);

        if (room == null)
        {
            return NotFound();
        }

        return room;
    }
    
    [HttpPut]
    public async Task<IActionResult> PutRoom(Room room)
    {
        _db.Entry(room).State = EntityState.Modified;
        
        await _db.SaveChangesAsync();

        return Ok(room);
    }
    
    [HttpPost]
    public async Task<ActionResult<Room>> PostRoom(Room room)
    {
        _db.Rooms.Add(room);
        await _db.SaveChangesAsync();

        return Created("", room);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoom(int id)
    {
        var room = await _db.Rooms.FindAsync(id);
        if (room == null)
        {
            return NotFound();
        }

        _db.Rooms.Remove(room);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
