namespace AISSmartFactory.Models.Production;

public class MachineTelemetry
{
    public long Id { get; set; }

    public long MachineId { get; set; }

    public DateTime Timestamp { get; set; }

    public string TagName { get; set; } = string.Empty;

    public decimal? NumericValue { get; set; }

    public string? StringValue { get; set; }

    public bool? BooleanValue { get; set; }

    public string? Unit { get; set; }

    public string? Quality { get; set; }
}
