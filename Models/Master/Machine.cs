using AISSmartFactory.Models.Common;

namespace AISSmartFactory.Models.Master;

public class Machine : BaseEntity
{
    public string MachineCode { get; set; } = string.Empty;

    public string MachineName { get; set; } = string.Empty;

    public string? MachineType { get; set; }

    public string? Manufacturer { get; set; }

    public string? Model { get; set; }

    public string? Controller { get; set; }

    public string? SerialNumber { get; set; }

    public string? IPAddress { get; set; }

    public int? Port { get; set; }

    public string? Location { get; set; }

    public string? LineName { get; set; }

    public bool IsOnline { get; set; }

    public DateTime? LastCommunicationAt { get; set; }

    public string? CommunicationProtocol { get; set; }

    public string? Description { get; set; }
}
