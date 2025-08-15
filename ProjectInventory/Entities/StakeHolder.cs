using ProjectInventory.Enum;

namespace ProjectInventory.Entities;

public class StakeHolder : AuditableEntity
{
    public string Name { get; set; } = null!;
    public string VatNo { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public StakeHolderType Type { get; set; }
    public bool IsActive { get; set; } 
}