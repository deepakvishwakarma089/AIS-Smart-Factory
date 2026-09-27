using AISSmartFactory.Models.Common;
using AISSmartFactory.Models.Master;
using AISSmartFactory.Models.Production;

namespace AISSmartFactory.Models.Quality;

public class QualityInspection : BaseEntity
{
    public long ProductionRunId { get; set; }

    public ProductionRun ProductionRun { get; set; } = null!;

    public long? OperatorId { get; set; }

    public Operator? Operator { get; set; }

    public DateTime InspectionTime { get; set; }

    public string InspectionType { get; set; } = "FirstPiece";

    public string Result { get; set; } = "Pending";

    public string? InspectorName { get; set; }

    public string? Remarks { get; set; }

    public string? InspectionPhotoPath { get; set; }
}
