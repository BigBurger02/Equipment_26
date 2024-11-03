namespace Equipment_26.Model;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public int RoomId { get; set; }
    public Room? Room { get; set; }

    public int ResponsibleId { get; set; }
    public Responsible? Responsible { get; set; }
}