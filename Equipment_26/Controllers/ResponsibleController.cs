using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equipment_26.Data;
using Equipment_26.Model;

namespace Equipment_26.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponsibleController : ControllerBase
{
    private readonly AppDbContext _db;

    public ResponsibleController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Responsible>>> GetResponsible()
    {
        return Ok(await _db.Responsible.ToListAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Responsible>> GetResponsible(int id)
    {
        var responsible = await _db.Responsible.FindAsync(id);

        if (responsible == null)
        {
            return NotFound();
        }

        return responsible;
    }
    
    [HttpPut]
    public async Task<IActionResult> PutResponsible(Responsible responsible)
    {
        _db.Entry(responsible).State = EntityState.Modified;
        
        await _db.SaveChangesAsync();

        return Ok(responsible);
    }
    
    [HttpPost]
    public async Task<ActionResult<Responsible>> PostResponsible(Responsible responsible)
    {
        _db.Responsible.Add(responsible);
        await _db.SaveChangesAsync();

        return Created("", responsible);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteResponsible(int id)
    {
        var responsible = await _db.Responsible.FindAsync(id);
        if (responsible == null)
        {
            return NotFound();
        }

        _db.Responsible.Remove(responsible);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
