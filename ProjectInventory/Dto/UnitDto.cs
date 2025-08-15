namespace ProjectInventory.Dto;

public class UnitDto
{
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string? Description { get; set; } 
    public bool IsActive { get; set; }
}