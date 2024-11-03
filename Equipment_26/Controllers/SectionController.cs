using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Equipment_26.Data;
using Equipment_26.Model;

namespace Equipment_26.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SectionController : ControllerBase
{
    private readonly AppDbContext _db;

    public SectionController(AppDbContext db)
    {
        _db = db;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Section>>> GetSections()
    {
        return Ok(await _db.Sections.ToListAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Section>> GetSection(int id)
    {
        var section = await _db.Sections.FindAsync(id);

        if (section == null)
        {
            return NotFound();
        }

        return section;
    }
    
    [HttpPut]
    public async Task<IActionResult> PutSection(Section section)
    {
        _db.Entry(section).State = EntityState.Modified;
        
        await _db.SaveChangesAsync();

        return Ok(section);
    }
    
    [HttpPost]
    public async Task<ActionResult<Section>> PostSection(Section section)
    {
        _db.Sections.Add(section);
        await _db.SaveChangesAsync();

        return Created("", section);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSection(int id)
    {
        var section = await _db.Sections.FindAsync(id);
        if (section == null)
        {
            return NotFound();
        }

        _db.Sections.Remove(section);
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
