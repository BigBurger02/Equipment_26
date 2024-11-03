namespace Equipment_26.Model;

public class Room
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;

    public int SectionId { get; set; }
    public Section? Section { get; set; }
}