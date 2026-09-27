using AISSmartFactory.Models.Common;

namespace AISSmartFactory.Models.Master;

public class Operator : BaseEntity
{
    public string EmployeeCode { get; set; } = string.Empty;

    public string EmployeeName { get; set; } = string.Empty;

    public string? Department { get; set; }

    public string? Designation { get; set; }

    public string? Shift { get; set; }

    public string? ContactNumber { get; set; }
}
