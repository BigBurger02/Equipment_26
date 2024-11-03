namespace Equipment_26.Model;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public List<Room>? Rooms { get; set; }
}