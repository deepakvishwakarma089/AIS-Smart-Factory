using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;
using AISSmartFactory.Models.Production;

namespace AISSmartFactory.Models.Quality;

public class QualityDefect : BaseEntity
{
    public long ProductionRunId { get; set; }

    public ProductionRun ProductionRun { get; set; } = null!;

    public long DefectTypeId { get; set; }

    public DefectType DefectType { get; set; } = null!;

    public string? Location { get; set; }

    public string Severity { get; set; } = "Minor";

    public string? Description { get; set; }

    public string? PhotoPath { get; set; }

    public DateTime DetectedAt { get; set; }

    public string Disposition { get; set; } = "Pending";

    public string? CorrectiveAction { get; set; }
}
