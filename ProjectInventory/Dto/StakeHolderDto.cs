using ProjectInventory.Enum;

namespace ProjectInventory.Dto;

public class StakeHolderDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string VatNo { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public StakeHolderType Type { get; set; }
    public bool IsActive { get; set; } 
}