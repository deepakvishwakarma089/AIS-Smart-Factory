using System.ComponentModel.DataAnnotations;

namespace AISSmartFactory.Models.Production;

public class CncDowntimeEntry
{
    public long Id { get; set; }

    public long CncProductionEntryId { get; set; }

    public long MachineId { get; set; }

    public long DowntimeReasonId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public decimal DurationMinutes { get; set; }

    [StringLength(1000)]
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
