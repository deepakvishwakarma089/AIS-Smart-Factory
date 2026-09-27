using AISSmartFactory.Models.Common;

namespace AISSmartFactory.Models.Quality;

public class QualityMeasurement : BaseEntity
{
    public long QualityInspectionId { get; set; }

    public QualityInspection QualityInspection { get; set; } = null!;

    public string ParameterName { get; set; } = string.Empty;

    public string? ParameterCode { get; set; }

    public decimal SpecificationNominal { get; set; }

    public decimal? LowerLimit { get; set; }

    public decimal? UpperLimit { get; set; }

    public decimal ActualValue { get; set; }

    public decimal? Deviation { get; set; }

    public string Unit { get; set; } = "mm";

    public bool IsPassed { get; set; }

    public string? MeasuringInstrument { get; set; }

    public string? Remarks { get; set; }
}
