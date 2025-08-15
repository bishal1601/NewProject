using System.ComponentModel.DataAnnotations;

namespace ProjectInventory.Models;

public class CategoryEditVm
{
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(50,MinimumLength=3,ErrorMessage="String must be 3 to 50 character long")]
    public string Name { get; set; } = string.Empty;
    
    [StringLength(500,MinimumLength=10,ErrorMessage="The description must be between 10 to 500 characters long")]
    public string Description { get; set; } = string.Empty;
    
    public bool IsActive { get; set; }
}