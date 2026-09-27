using System.ComponentModel.DataAnnotations;

namespace AISSmartFactory.Models.Master;

public class CncProgram
{
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ProgramCode { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string ProgramName { get; set; } = string.Empty;

    [StringLength(100)]
    public string? ProgramNumber { get; set; }

    public long? MachineId { get; set; }

    public long? GlassTypeId { get; set; }

    [StringLength(100)]
    public string? OperationType { get; set; }

    public decimal? TargetCycleTime { get; set; }

    [StringLength(50)]
    public string? Revision { get; set; }

    [StringLength(500)]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    public Machine? Machine { get; set; }

    public GlassType? GlassType { get; set; }
}