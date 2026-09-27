using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;

namespace AISSmartFactory.Models.Maintenance;

public class MaintenanceRecord : BaseEntity
{
    public long MachineId { get; set; }

    public Machine Machine { get; set; } = null!;

    public string MaintenanceType { get; set; } = "Preventive";

    public string? MaintenanceStatus { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public string? ProblemDescription { get; set; }

    public string? RootCause { get; set; }

    public string? CorrectiveAction { get; set; }

    public string? Technician { get; set; }

    public string? SparePartsUsed { get; set; }

    public decimal? MachineRunningHours { get; set; }

    public DateTime? NextDueDate { get; set; }

    public string? Remarks { get; set; }
}
