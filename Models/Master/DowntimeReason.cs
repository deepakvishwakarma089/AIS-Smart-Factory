
using AISSmartFactory.Models.Common;

namespace AISSmartFactory.Models.Master;

public class DowntimeReason : BaseEntity
{
    public string ReasonCode { get; set; } = string.Empty;

    public string ReasonName { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string? Description { get; set; }

    public bool IsPlanned { get; set; }

    public bool RequiresComment { get; set; }
}
