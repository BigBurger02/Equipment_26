namespace Equipment_26.Model;

public class Equipment
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string? SerialNumber { get; set; }
    public string? Type { get; set; }
    public string? Status { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public DateTime? WarrantyExpiry { get; set; }
    public DateTime? LastMaintenanceDate { get; set; }
    public bool IsOperational { get; set; }

    public int RoomId { get; set; }
    public Room? Room { get; set; }

    public int ResponsibleId { get; set; }
    public Responsible? Responsible { get; set; }
}