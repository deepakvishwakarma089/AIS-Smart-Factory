using System.ComponentModel.DataAnnotations;

namespace AISSmartFactory.Models.Production;

public class CncProductionEntry
{
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ProductionNumber { get; set; } = string.Empty;

    public DateTime ProductionDate { get; set; } = DateTime.Now;

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    // Master IDs
    public long MachineId { get; set; }

    public long OperatorId { get; set; }

    public long GlassTypeId { get; set; }

    public long CncProgramId { get; set; }

    public long? ToolId { get; set; }

    // Production
    public int PlannedQuantity { get; set; }

    public int ProducedQuantity { get; set; }

    public int GoodQuantity { get; set; }

    public int RejectedQuantity { get; set; }

    // Process parameters
    public decimal? CycleTimeSeconds { get; set; }

    public decimal? SpindleRpm { get; set; }

    public decimal? FeedRate { get; set; }

    public decimal? CuttingDepth { get; set; }

    public decimal? CoolantPressure { get; set; }

    public decimal? AirPressure { get; set; }

    public decimal? MachineLoadPercent { get; set; }

    public decimal? EnergyKwh { get; set; }

    // Quality
    public bool QualityApproved { get; set; }

    [StringLength(1000)]
    public string? QualityRemarks { get; set; }

    // Production comments
    [StringLength(1000)]
    public string? Remarks { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
