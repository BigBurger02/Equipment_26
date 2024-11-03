namespace Equipment_26.Model;

public class Responsible
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? Position { get; set; } = String.Empty;
    public string? PhoneNumber { get; set; }
    public DateTime? HiredDate { get; set; }
    public string? ShiftTiming { get; set; }
}