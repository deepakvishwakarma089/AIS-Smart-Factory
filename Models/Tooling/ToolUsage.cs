using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;
using AISSmartFactory.Models.Production;

namespace AISSmartFactory.Models.Tooling;

public class ToolUsage : BaseEntity
{
    public long ToolId { get; set; }

    public Tool Tool { get; set; } = null!;

    public long MachineId { get; set; }

    public Machine Machine { get; set; } = null!;

    public long? ProductionRunId { get; set; }

    public ProductionRun? ProductionRun { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int PieceCount { get; set; }

    public decimal? UsageHours { get; set; }

    public int? RemainingLifePieces { get; set; }

    public decimal? RemainingLifeHours { get; set; }

    public string? Condition { get; set; }

    public string? Remarks { get; set; }
}
