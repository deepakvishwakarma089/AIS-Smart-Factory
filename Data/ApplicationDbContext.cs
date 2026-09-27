using AISSmartFactory.Models.Maintenance;
using AISSmartFactory.Models.Master;
using AISSmartFactory.Models.Production;
using AISSmartFactory.Models.Quality;
using AISSmartFactory.Models.Tooling;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AISSmartFactory.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // =========================================================
    // MASTER
    // =========================================================

    public DbSet<Machine> Machines => Set<Machine>();

    public DbSet<Operator> Operators => Set<Operator>();

    public DbSet<GlassType> GlassTypes => Set<GlassType>();

    public DbSet<CncProgram> CncPrograms => Set<CncProgram>();

    public DbSet<Tool> Tools => Set<Tool>();

    public DbSet<DefectType> DefectTypes => Set<DefectType>();

    public DbSet<DowntimeReason> DowntimeReasons => Set<DowntimeReason>();

    public DbSet<CncProductionEntry> CncProductionEntries => Set<CncProductionEntry>();
    // =========================================================
    // PRODUCTION
    // =========================================================

    public DbSet<ProductionOrder> ProductionOrders => Set<ProductionOrder>();

    public DbSet<ProductionRun> ProductionRuns => Set<ProductionRun>();

    public DbSet<CncProcessData> CncProcessData => Set<CncProcessData>();

    public DbSet<MachineTelemetry> MachineTelemetry => Set<MachineTelemetry>();

    public DbSet<MachineAlarm> MachineAlarms => Set<MachineAlarm>();

    public DbSet<MachineDowntime> MachineDowntime => Set<MachineDowntime>();


    // =========================================================
    // QUALITY
    // =========================================================

    public DbSet<QualityInspection> QualityInspections => Set<QualityInspection>();

    public DbSet<QualityMeasurement> QualityMeasurements => Set<QualityMeasurement>();

    public DbSet<QualityDefect> QualityDefects => Set<QualityDefect>();


    // =========================================================
    // TOOLING
    // =========================================================

    public DbSet<ToolUsage> ToolUsages => Set<ToolUsage>();


    // =========================================================
    // MAINTENANCE
    // =========================================================

    public DbSet<MaintenanceRecord> MaintenanceRecords => Set<MaintenanceRecord>();


    // =========================================================
    // MODEL CONFIGURATION
    // =========================================================

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureMasterModels(modelBuilder);

        ConfigureProductionModels(modelBuilder);

        ConfigureQualityModels(modelBuilder);

        ConfigureToolingModels(modelBuilder);

        ConfigureMaintenanceModels(modelBuilder);
    }


    // =========================================================
    // MASTER CONFIGURATION
    // =========================================================

    private static void ConfigureMasterModels(ModelBuilder modelBuilder)
    {
        // -----------------------------------------------------
        // Machine
        // -----------------------------------------------------

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.ToTable("Machines");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.MachineCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.MachineName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.MachineType)
                .HasMaxLength(100);

            entity.Property(x => x.Manufacturer)
                .HasMaxLength(100);

            entity.Property(x => x.Model)
                .HasMaxLength(100);

            entity.Property(x => x.Controller)
                .HasMaxLength(100);

            entity.Property(x => x.SerialNumber)
                .HasMaxLength(100);

            entity.Property(x => x.IPAddress)
                .HasMaxLength(50);

            entity.Property(x => x.Location)
                .HasMaxLength(150);

            entity.Property(x => x.LineName)
                .HasMaxLength(100);

            entity.Property(x => x.CommunicationProtocol)
                .HasMaxLength(50);

            entity.Property(x => x.Description)
                .HasMaxLength(500);

            entity.HasIndex(x => x.MachineCode)
                .IsUnique();

            entity.HasIndex(x => x.IPAddress);
        });


        // -----------------------------------------------------
        // Operator
        // -----------------------------------------------------

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.ToTable("Operators");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.EmployeeCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.EmployeeName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.Department)
                .HasMaxLength(100);

            entity.Property(x => x.Designation)
                .HasMaxLength(100);

            entity.Property(x => x.Shift)
                .HasMaxLength(50);

            entity.Property(x => x.ContactNumber)
                .HasMaxLength(30);

            entity.HasIndex(x => x.EmployeeCode)
                .IsUnique();
        });


        // -----------------------------------------------------
        // Glass Type
        // -----------------------------------------------------

        modelBuilder.Entity<GlassType>(entity =>
        {
            entity.ToTable("GlassTypes");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.GlassCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.GlassName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.GlassCategory)
                .HasMaxLength(100);

            entity.Property(x => x.CoatingType)
                .HasMaxLength(100);

            entity.Property(x => x.Grade)
                .HasMaxLength(100);

            entity.Property(x => x.Thickness)
                .HasPrecision(10, 3);

            entity.Property(x => x.Length)
                .HasPrecision(12, 3);

            entity.Property(x => x.Width)
                .HasPrecision(12, 3);

            entity.Property(x => x.Weight)
                .HasPrecision(12, 3);

            entity.Property(x => x.Description)
                .HasMaxLength(500);

            entity.HasIndex(x => x.GlassCode)
                .IsUnique();
        });


        // -----------------------------------------------------
        // CNC Program
        // -----------------------------------------------------

        modelBuilder.Entity<CncProgram>(entity =>
        {
            entity.ToTable("CncPrograms");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.ProgramNumber)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.ProgramName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.Revision)
                .HasMaxLength(50);

            entity.Property(x => x.Description)
                .HasMaxLength(500);

            entity.HasIndex(x => new
            {
                x.ProgramNumber,
                x.Revision
            });

            entity.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.SetNull);
        });


        // -----------------------------------------------------
        // Tool
        // -----------------------------------------------------

        modelBuilder.Entity<Tool>(entity =>
        {
            entity.ToTable("Tools");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.ToolCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.ToolName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.ToolType)
                .HasMaxLength(100);

            entity.Property(x => x.ToolNumber)
                .HasMaxLength(50);

            entity.Property(x => x.Manufacturer)
                .HasMaxLength(100);

            entity.Property(x => x.Diameter)
                .HasPrecision(10, 3);

            entity.Property(x => x.Length)
                .HasPrecision(10, 3);


            entity.HasIndex(x => x.ToolCode)
                .IsUnique();
        });


        // -----------------------------------------------------
        // Defect Type
        // -----------------------------------------------------

        modelBuilder.Entity<DefectType>(entity =>
        {
            entity.ToTable("DefectTypes");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.Category)
                .HasMaxLength(100);

            entity.Property(x => x.Severity)
                .HasMaxLength(50);

            entity.Property(x => x.Description)
                .HasMaxLength(500);

            entity.HasIndex(x => x.Code)
                .IsUnique();
        });


        // -----------------------------------------------------
        // Downtime Reason
        // -----------------------------------------------------

      
modelBuilder.Entity<DowntimeReason>(entity =>
{
    entity.ToTable("DowntimeReasons");

    entity.HasKey(x => x.Id);

    entity.Property(x => x.ReasonCode)
        .IsRequired()
        .HasMaxLength(50);

    entity.Property(x => x.ReasonName)
        .IsRequired()
        .HasMaxLength(150);

    entity.Property(x => x.Category)
        .IsRequired()
        .HasMaxLength(100);

    entity.Property(x => x.Description)
        .HasMaxLength(500);

    entity.Property(x => x.IsPlanned)
        .IsRequired();

    entity.Property(x => x.RequiresComment)
        .IsRequired();

    entity.HasIndex(x => x.ReasonCode)
        .IsUnique();
});

    }


    // =========================================================
    // PRODUCTION CONFIGURATION
    // =========================================================

    private static void ConfigureProductionModels(ModelBuilder modelBuilder)
    {
        // -----------------------------------------------------
        // Production Order
        // -----------------------------------------------------

        modelBuilder.Entity<ProductionOrder>(entity =>
        {
            entity.ToTable("ProductionOrders");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.OrderNumber)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.PartNumber)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.PartName)
                .HasMaxLength(150);

            entity.Property(x => x.CustomerName)
                .HasMaxLength(200);

            entity.Property(x => x.DrawingNumber)
                .HasMaxLength(100);

            entity.Property(x => x.DrawingRevision)
                .HasMaxLength(50);

            entity.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.Remarks)
                .HasMaxLength(500);

            entity.HasIndex(x => x.OrderNumber)
                .IsUnique();

            entity.HasIndex(x => x.MachineId);

            entity.HasIndex(x => x.GlassTypeId);

            entity.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.GlassType)
                .WithMany()
                .HasForeignKey(x => x.GlassTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.CncProgram)
                .WithMany()
                .HasForeignKey(x => x.CncProgramId)
                .OnDelete(DeleteBehavior.SetNull);
        });


        // -----------------------------------------------------
        // Production Run
        // -----------------------------------------------------

        modelBuilder.Entity<ProductionRun>(entity =>
        {
            entity.ToTable("ProductionRuns");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.PieceNumber)
                .HasMaxLength(100);

            entity.Property(x => x.Barcode)
                .HasMaxLength(150);

            entity.Property(x => x.CycleTimeSeconds)
                .HasPrecision(12, 3);

            entity.Property(x => x.Status)
                .HasMaxLength(50);

            entity.Property(x => x.RejectionReason)
                .HasMaxLength(250);

            entity.Property(x => x.Remarks)
                .HasMaxLength(500);

            entity.HasIndex(x => x.ProductionOrderId);

            entity.HasIndex(x => x.MachineId);

            entity.HasIndex(x => x.Barcode);

            entity.HasIndex(x => x.StartTime);

            entity.HasOne(x => x.ProductionOrder)
                .WithMany()
                .HasForeignKey(x => x.ProductionOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Operator)
                .WithMany()
                .HasForeignKey(x => x.OperatorId)
                .OnDelete(DeleteBehavior.SetNull);
        });


        // -----------------------------------------------------
        // CNC Process Data
        // -----------------------------------------------------

        modelBuilder.Entity<CncProcessData>(entity =>
        {
            entity.ToTable("CncProcessData");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.SpindleRpm)
                .HasPrecision(12, 2);

            entity.Property(x => x.FeedRate)
                .HasPrecision(12, 3);

            entity.Property(x => x.SpindleLoad)
                .HasPrecision(8, 3);

            entity.Property(x => x.MotorCurrent)
                .HasPrecision(10, 3);

            entity.Property(x => x.XPosition)
                .HasPrecision(12, 3);

            entity.Property(x => x.YPosition)
                .HasPrecision(12, 3);

            entity.Property(x => x.ZPosition)
                .HasPrecision(12, 3);

            entity.Property(x => x.CuttingDepth)
                .HasPrecision(12, 3);

            entity.Property(x => x.CoolantPressure)
                .HasPrecision(10, 3);

            entity.Property(x => x.CoolantFlow)
                .HasPrecision(10, 3);

            entity.Property(x => x.CoolantTemperature)
                .HasPrecision(8, 3);

            entity.Property(x => x.AirPressure)
                .HasPrecision(10, 3);

            entity.Property(x => x.VacuumPressure)
                .HasPrecision(10, 3);

            entity.Property(x => x.MachineTemperature)
                .HasPrecision(8, 3);

            entity.Property(x => x.Vibration)
                .HasPrecision(10, 3);

            entity.Property(x => x.CycleTimeSeconds)
                .HasPrecision(12, 3);

            entity.HasIndex(x => x.MachineId);

            entity.HasIndex(x => x.ProductionRunId);

            entity.HasIndex(x => x.Timestamp);

            entity.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.ProductionRun)
                .WithMany()
                .HasForeignKey(x => x.ProductionRunId)
                .OnDelete(DeleteBehavior.Cascade);
        });


        // -----------------------------------------------------
        // Machine Telemetry
        // -----------------------------------------------------

        modelBuilder.Entity<MachineTelemetry>(entity =>
        {
            entity.ToTable("MachineTelemetry");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.TagName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.NumericValue)
                .HasPrecision(18, 6);

            entity.Property(x => x.StringValue)
                .HasMaxLength(500);

            entity.Property(x => x.Unit)
                .HasMaxLength(50);

            entity.Property(x => x.Quality)
                .HasMaxLength(50);

            entity.HasIndex(x => new
            {
                x.MachineId,
                x.Timestamp
            });

            entity.HasIndex(x => new
            {
                x.MachineId,
                x.TagName,
                x.Timestamp
            });
        });


        // -----------------------------------------------------
        // Machine Alarm
        // -----------------------------------------------------

        modelBuilder.Entity<MachineAlarm>(entity =>
        {
            entity.ToTable("MachineAlarms");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.AlarmCode)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(x => x.AlarmMessage)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(x => x.AlarmType)
                .HasMaxLength(100);

            entity.Property(x => x.Severity)
                .HasMaxLength(50);

            entity.Property(x => x.DurationSeconds)
                .HasPrecision(12, 3);

            entity.Property(x => x.AcknowledgedBy)
                .HasMaxLength(150);

            entity.HasIndex(x => x.MachineId);

            entity.HasIndex(x => x.StartTime);

            entity.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Restrict);
        });


        // -----------------------------------------------------
        // Machine Downtime
        // -----------------------------------------------------

        modelBuilder.Entity<MachineDowntime>(entity =>
        {
            entity.ToTable("MachineDowntime");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.DurationMinutes)
                .HasPrecision(12, 3);

            entity.Property(x => x.Remarks)
                .HasMaxLength(500);

            entity.Property(x => x.CorrectiveAction)
                .HasMaxLength(500);

            entity.HasIndex(x => x.MachineId);

            entity.HasIndex(x => x.StartTime);

            entity.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.DowntimeReason)
                .WithMany()
                .HasForeignKey(x => x.DowntimeReasonId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Operator)
                .WithMany()
                .HasForeignKey(x => x.OperatorId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }


    // =========================================================
    // QUALITY CONFIGURATION
    // =========================================================

    private static void ConfigureQualityModels(ModelBuilder modelBuilder)
    {
        // -----------------------------------------------------
        // Quality Inspection
        // -----------------------------------------------------

        modelBuilder.Entity<QualityInspection>(entity =>
        {
            entity.ToTable("QualityInspections");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.InspectionType)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.Result)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.InspectorName)
                .HasMaxLength(150);

            entity.Property(x => x.Remarks)
                .HasMaxLength(500);

            entity.Property(x => x.InspectionPhotoPath)
                .HasMaxLength(500);

            entity.HasIndex(x => x.ProductionRunId);

            entity.HasIndex(x => x.InspectionTime);

            entity.HasOne(x => x.ProductionRun)
                .WithMany()
                .HasForeignKey(x => x.ProductionRunId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.Operator)
                .WithMany()
                .HasForeignKey(x => x.OperatorId)
                .OnDelete(DeleteBehavior.SetNull);
        });


        // -----------------------------------------------------
        // Quality Measurement
        // -----------------------------------------------------

        modelBuilder.Entity<QualityMeasurement>(entity =>
        {
            entity.ToTable("QualityMeasurements");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.ParameterName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(x => x.ParameterCode)
                .HasMaxLength(100);

            entity.Property(x => x.SpecificationNominal)
                .HasPrecision(18, 6);

            entity.Property(x => x.LowerLimit)
                .HasPrecision(18, 6);

            entity.Property(x => x.UpperLimit)
                .HasPrecision(18, 6);

            entity.Property(x => x.ActualValue)
                .HasPrecision(18, 6);

            entity.Property(x => x.Deviation)
                .HasPrecision(18, 6);

            entity.Property(x => x.Unit)
                .HasMaxLength(30);

            entity.Property(x => x.MeasuringInstrument)
                .HasMaxLength(150);

            entity.Property(x => x.Remarks)
                .HasMaxLength(500);

            entity.HasIndex(x => x.QualityInspectionId);

            entity.HasOne(x => x.QualityInspection)
                .WithMany()
                .HasForeignKey(x => x.QualityInspectionId)
                .OnDelete(DeleteBehavior.Cascade);
        });


        // -----------------------------------------------------
        // Quality Defect
        // -----------------------------------------------------

        modelBuilder.Entity<QualityDefect>(entity =>
        {
            entity.ToTable("QualityDefects");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Location)
                .HasMaxLength(150);

            entity.Property(x => x.Severity)
                .HasMaxLength(50);

            entity.Property(x => x.Description)
                .HasMaxLength(500);

            entity.Property(x => x.PhotoPath)
                .HasMaxLength(500);

            entity.Property(x => x.Disposition)
                .HasMaxLength(100);

            entity.Property(x => x.CorrectiveAction)
                .HasMaxLength(500);

            entity.HasIndex(x => x.ProductionRunId);

            entity.HasIndex(x => x.DefectTypeId);

            entity.HasIndex(x => x.DetectedAt);

            entity.HasOne(x => x.ProductionRun)
                .WithMany()
                .HasForeignKey(x => x.ProductionRunId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(x => x.DefectType)
                .WithMany()
                .HasForeignKey(x => x.DefectTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }


    // =========================================================
    // TOOLING CONFIGURATION
    // =========================================================

    private static void ConfigureToolingModels(ModelBuilder modelBuilder)
    {
        // -----------------------------------------------------
        // Tool Usage
        // -----------------------------------------------------

        modelBuilder.Entity<ToolUsage>(entity =>
        {
            entity.ToTable("ToolUsages");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.UsageHours)
                .HasPrecision(12, 3);

            entity.Property(x => x.RemainingLifeHours)
                .HasPrecision(12, 3);

            entity.Property(x => x.Condition)
                .HasMaxLength(100);

            entity.Property(x => x.Remarks)
                .HasMaxLength(500);

            entity.HasIndex(x => x.ToolId);

            entity.HasIndex(x => x.MachineId);

            entity.HasIndex(x => x.ProductionRunId);

            entity.HasIndex(x => x.StartTime);

            entity.HasOne(x => x.Tool)
                .WithMany()
                .HasForeignKey(x => x.ToolId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(x => x.ProductionRun)
                .WithMany()
                .HasForeignKey(x => x.ProductionRunId)
                .OnDelete(DeleteBehavior.SetNull);
        });
    }


    // =========================================================
    // MAINTENANCE CONFIGURATION
    // =========================================================

    private static void ConfigureMaintenanceModels(
        ModelBuilder modelBuilder)
    {
        // -----------------------------------------------------
        // Maintenance Record
        // -----------------------------------------------------

        modelBuilder.Entity<MaintenanceRecord>(entity =>
        {
            entity.ToTable("MaintenanceRecords");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.MaintenanceType)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(x => x.MaintenanceStatus)
                .HasMaxLength(50);

            entity.Property(x => x.ProblemDescription)
                .HasMaxLength(1000);

            entity.Property(x => x.RootCause)
                .HasMaxLength(1000);

            entity.Property(x => x.CorrectiveAction)
                .HasMaxLength(1000);

            entity.Property(x => x.Technician)
                .HasMaxLength(150);

            entity.Property(x => x.SparePartsUsed)
                .HasMaxLength(1000);

            entity.Property(x => x.MachineRunningHours)
                .HasPrecision(12, 3);

            entity.Property(x => x.Remarks)
                .HasMaxLength(500);

            entity.HasIndex(x => x.MachineId);

            entity.HasIndex(x => x.StartTime);

            entity.HasIndex(x => x.NextDueDate);

            entity.HasOne(x => x.Machine)
                .WithMany()
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}