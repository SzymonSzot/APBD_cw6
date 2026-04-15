using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models;

public class Room

{
    private static int _id = 0;
    
    public int Id { get; set; }
    
    [Required] public string Name { get; set; }
    [Required] public string BuildingCode { get; set; }
    public int Floor { get; set; }
    [Range(1, int.MaxValue)] public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool IsActive { get; set; }

    public Room(string name, string buildingCode, int floor, int capacity, bool hasProjector, bool isActive)
    {
        Id = _id++; 
        Name = name;
        BuildingCode = buildingCode;
        Floor = floor;
        Capacity = capacity;
        HasProjector = hasProjector;
        IsActive = isActive;
    }
}