using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;

namespace AISSmartFactory.Models.Production;

public class MachineAlarm : BaseEntity
{
    public long MachineId { get; set; }

    public Machine Machine { get; set; } = null!;

    public string AlarmCode { get; set; } = string.Empty;

    public string AlarmMessage { get; set; } = string.Empty;

    public string? AlarmType { get; set; }

    public string Severity { get; set; } = "Warning";

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal? DurationSeconds { get; set; }

    public bool IsAcknowledged { get; set; }

    public string? AcknowledgedBy { get; set; }

    public DateTime? AcknowledgedAt { get; set; }
}
