namespace Equipment_26.Model;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public int? FlourCount { get; set; }

    public List<Room>? Rooms { get; set; }
}