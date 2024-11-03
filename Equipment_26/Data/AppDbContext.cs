using Equipment_26.Model;
using Microsoft.EntityFrameworkCore;

namespace Equipment_26.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Section> Sections { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Responsible> Responsible { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
}