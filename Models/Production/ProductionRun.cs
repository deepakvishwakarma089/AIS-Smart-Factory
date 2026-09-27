using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;

namespace AISSmartFactory.Models.Production;

public class ProductionRun : BaseEntity
{
    public long ProductionOrderId { get; set; }

    public ProductionOrder ProductionOrder { get; set; } = null!;

    public long MachineId { get; set; }

    public Machine Machine { get; set; } = null!;

    public long? OperatorId { get; set; }

    public Operator? Operator { get; set; }

    public string? PieceNumber { get; set; }

    public string? Barcode { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal? CycleTimeSeconds { get; set; }

    public string Status { get; set; } = "Running";

    public bool IsGood { get; set; }

    public string? RejectionReason { get; set; }

    public string? Remarks { get; set; }
}
