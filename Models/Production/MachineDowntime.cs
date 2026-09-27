
using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;

namespace AISSmartFactory.Models.Production;

public class MachineDowntime : BaseEntity
{
    public long MachineId { get; set; }

    public Machine Machine { get; set; } = null!;

    public long DowntimeReasonId { get; set; }

    public DowntimeReason DowntimeReason { get; set; } = null!;

    public long? OperatorId { get; set; }

    public Operator? Operator { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal? DurationMinutes { get; set; }

    public string? Remarks { get; set; }

    public string? CorrectiveAction { get; set; }
}

