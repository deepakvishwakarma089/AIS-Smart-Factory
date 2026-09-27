using System.ComponentModel.DataAnnotations;

namespace AISSmartFactory.Models.Master;

public class DowntimeReason
{
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ReasonCode { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string ReasonName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Category { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }

    public bool IsPlanned { get; set; }

    public bool RequiresComment { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
