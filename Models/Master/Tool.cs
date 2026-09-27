using System.ComponentModel.DataAnnotations;

namespace AISSmartFactory.Models.Master;

public class Tool
{
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string ToolCode { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string ToolName { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string ToolType { get; set; } = string.Empty;

    [StringLength(100)]
    public string? ToolNumber { get; set; }

    [StringLength(100)]
    public string? Manufacturer { get; set; }

    [StringLength(150)]
    public string? Specification { get; set; }

    public decimal? Diameter { get; set; }

    public decimal? Length { get; set; }

    public decimal? MaximumRpm { get; set; }

    public decimal? ExpectedLife { get; set; }

    public decimal CurrentLife { get; set; }

    [StringLength(50)]
    public string LifeUnit { get; set; } = "Pieces";

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}