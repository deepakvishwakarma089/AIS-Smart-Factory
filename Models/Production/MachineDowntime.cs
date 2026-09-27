```csharp
using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;

namespace AISSmartFactory.Models.Production;

public class MachineDowntime : BaseEntity
{
    // =========================================================
    // MACHINE
    // =========================================================

    public long MachineId { get; set; }

    public Machine Machine { get; set; } = null!;


    // =========================================================
    // DOWNTIME REASON
    // =========================================================

    public long DowntimeReasonId { get; set; }

    public DowntimeReason DowntimeReason { get; set; } = null!;


    // =========================================================
    // OPERATOR
    // =========================================================

    public long? OperatorId { get; set; }

    public Operator? Operator { get; set; }


    // =========================================================
    // TIME
    // =========================================================

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }


    // =========================================================
    // DURATION
    // =========================================================

    public decimal? DurationMinutes { get; set; }


    // =========================================================
    // DETAILS
    // =========================================================

    public string? Remarks { get; set; }

    public string? CorrectiveAction { get; set; }


    // =========================================================
    // CALCULATED DURATION
    // =========================================================

    public decimal? CalculatedDurationMinutes
    {
        get
        {
            if (!EndTime.HasValue)
                return null;

            return (decimal)(EndTime.Value - StartTime).TotalMinutes;
        }
    }
}
```
