using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;

namespace AISSmartFactory.Models.Production;

public class CncProcessData : BaseEntity
{
    public long ProductionRunId { get; set; }

    public ProductionRun ProductionRun { get; set; } = null!;

    public long MachineId { get; set; }

    public Machine Machine { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public decimal? SpindleRpm { get; set; }

    public decimal? FeedRate { get; set; }

    public decimal? SpindleLoad { get; set; }

    public decimal? MotorCurrent { get; set; }

    public decimal? XPosition { get; set; }

    public decimal? YPosition { get; set; }

    public decimal? ZPosition { get; set; }

    public decimal? CuttingDepth { get; set; }

    public decimal? CoolantPressure { get; set; }

    public decimal? CoolantFlow { get; set; }

    public decimal? CoolantTemperature { get; set; }

    public decimal? AirPressure { get; set; }

    public decimal? VacuumPressure { get; set; }

    public decimal? MachineTemperature { get; set; }

    public decimal? Vibration { get; set; }

    public decimal? CycleTimeSeconds { get; set; }
}
