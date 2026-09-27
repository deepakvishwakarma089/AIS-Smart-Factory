using AISSmartFactory.Models.Common;

namespace AISSmartFactory.Models.Master;

public class GlassType : BaseEntity
{
    public string GlassCode { get; set; } = string.Empty;

    public string GlassName { get; set; } = string.Empty;

    public string? GlassCategory { get; set; }

    public decimal Thickness { get; set; }

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal? Weight { get; set; }

    public string? CoatingType { get; set; }

    public string? Grade { get; set; }

    public string? Description { get; set; }
}
