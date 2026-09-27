using AISSmartFactory.Models.Common;

namespace AISSmartFactory.Models.Master;

public class DefectType : BaseEntity
{
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Category { get; set; }

    public string? Severity { get; set; }

    public string? Description { get; set; }
}
