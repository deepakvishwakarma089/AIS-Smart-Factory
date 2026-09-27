using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;

namespace AISSmartFactory.Models.Production;

public class ProductionOrder : BaseEntity
{
    public string OrderNumber { get; set; } = string.Empty;

    public string PartNumber { get; set; } = string.Empty;

    public string? PartName { get; set; }

    public string? CustomerName { get; set; }

    public string? DrawingNumber { get; set; }

    public string? DrawingRevision { get; set; }

    public long MachineId { get; set; }

    public Machine Machine { get; set; } = null!;

    public long GlassTypeId { get; set; }

    public GlassType GlassType { get; set; } = null!;

    public long? CncProgramId { get; set; }

    public CncProgram? CncProgram { get; set; }

    public int PlannedQuantity { get; set; }

    public int ProducedQuantity { get; set; }

    public int GoodQuantity { get; set; }

    public int RejectedQuantity { get; set; }

    public DateTime PlannedStart { get; set; }

    public DateTime? PlannedEnd { get; set; }

    public DateTime? ActualStart { get; set; }

    public DateTime? ActualEnd { get; set; }

    public string Status { get; set; } = "Planned";

    public string? Remarks { get; set; }
}
