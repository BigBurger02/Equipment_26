using System;
using System.Collections.Generic;
using System.Linq;
using Equipment_26.Model;
using Microsoft.EntityFrameworkCore;

namespace Equipment_26.Data;

public class DatabaseSeeder
{
    private readonly AppDbContext _context;

    public DatabaseSeeder(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (!_context.Equipment.Any())
        {
            var sections = GenerateSections();
            var rooms = GenerateRooms(sections);
            var responsible = GenerateResponsibles();
            var equipment = GenerateEquipment(rooms, responsible);

            _context.Sections.AddRange(sections);
            _context.Rooms.AddRange(rooms);
            _context.Responsible.AddRange(responsible);
            _context.Equipment.AddRange(equipment);
            _context.SaveChanges();
        }
    }

    private List<Section> GenerateSections()
    {
        var names = new[] { "Gerald", "Nick", "Alish", "Lucas", "John" };
        var random = new Random();
        return Enumerable.Range(1, 20).Select(i => new Section
        {
            Name = names[random.Next(names.Length)],
            FlourCount = random.Next(1, 4)
        }).ToList();
    }

    private List<Room> GenerateRooms(List<Section> sections)
    {
        var roomNames = new[] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon" };
        var roomTypes = new[] { "Lecture Hall", "Lab", "Meeting Room" };
        var random = new Random();
        var rooms = new List<Room>();

        foreach (var section in sections)
        {
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                rooms.Add(new Room
                {
                    Name = roomNames[random.Next(roomNames.Length)],
                    Type = roomTypes[random.Next(roomTypes.Length)],
                    Capacity = random.Next(10, 100),
                    Section = section
                });
            }
        }

        return rooms;
    }

    private List<Responsible> GenerateResponsibles()
    {
        var names = new[] { "Alice", "Bob", "Eve", "Frank", "Grace" };
        var positions = new[] { "Manager", "Supervisor", "Technician" };
        var random = new Random();

        return Enumerable.Range(1, 20).Select(i => new Responsible
        {
            Name = names[random.Next(names.Length)],
            Position = positions[random.Next(positions.Length)],
            PhoneNumber = $"123-456-{random.Next(1000, 9999)}",
            HiredDate = DateTime.Now.AddDays(-random.Next(30, 3650)),
            ShiftTiming = $"{random.Next(7, 11)}:00 AM - {random.Next(2, 10)}:00 PM"
        }).ToList();
    }

    private List<Equipment> GenerateEquipment(List<Room> rooms, List<Responsible> responsibles)
    {
        var equipmentNames = new[] { "Projector", "Computer", "Whiteboard", "Camera" };
        var types = new[] { "Electronics", "Furniture", "Stationery" };
        var statuses = new[] { "Operational", "Under Maintenance", "Out of Service" };
        var random = new Random();
        var equipmentList = new List<Equipment>();

        foreach (var room in rooms)
        {
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                var responsible = responsibles[random.Next(responsibles.Count)];
                equipmentList.Add(new Equipment
                {
                    Name = equipmentNames[random.Next(equipmentNames.Length)],
                    SerialNumber = $"SN-{random.Next(1000, 9999)}",
                    Type = types[random.Next(types.Length)],
                    Status = statuses[random.Next(statuses.Length)],
                    PurchaseDate = DateTime.Now.AddMonths(-random.Next(1, 60)),
                    WarrantyExpiry = DateTime.Now.AddMonths(random.Next(1, 60)),
                    LastMaintenanceDate = DateTime.Now.AddMonths(-random.Next(1, 12)),
                    IsOperational = random.NextDouble() > 0.2,
                    Room = room,
                    Responsible = responsible
                });
            }
        }

        return equipmentList;
    }
}
