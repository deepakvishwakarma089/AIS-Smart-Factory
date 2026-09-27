using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AISSmartFactory.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefectTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Severity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DowntimeReasons",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Reason = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Category = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsPlanned = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DowntimeReasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlassTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GlassCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    GlassName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    GlassCategory = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Thickness = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: false),
                    Length = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    Width = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    Weight = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    CoatingType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Grade = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlassTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MachineName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    MachineType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Manufacturer = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Model = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Controller = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    SerialNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IPAddress = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Port = table.Column<int>(type: "INTEGER", nullable: true),
                    Location = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    LineName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsOnline = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastCommunicationAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CommunicationProtocol = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineTelemetry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TagName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    NumericValue = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: true),
                    StringValue = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    BooleanValue = table.Column<bool>(type: "INTEGER", nullable: true),
                    Unit = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Quality = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTelemetry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    EmployeeName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Department = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Designation = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Shift = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ContactNumber = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ToolCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ToolName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    ToolType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ToolNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Diameter = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: true),
                    Length = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: true),
                    Manufacturer = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Material = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ExpectedLifePieces = table.Column<int>(type: "INTEGER", nullable: true),
                    ExpectedLifeHours = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CncPrograms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProgramNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ProgramName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Revision = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: true),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    FilePath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CncPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CncPrograms_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "MachineAlarms",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    AlarmCode = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AlarmMessage = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    AlarmType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Severity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DurationSeconds = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    IsAcknowledged = table.Column<bool>(type: "INTEGER", nullable: false),
                    AcknowledgedBy = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    AcknowledgedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineAlarms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineAlarms_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    MaintenanceType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MaintenanceStatus = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ProblemDescription = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    RootCause = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    CorrectiveAction = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Technician = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    SparePartsUsed = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    MachineRunningHours = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    NextDueDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineDowntime",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    DowntimeReasonId = table.Column<long>(type: "INTEGER", nullable: false),
                    OperatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DurationMinutes = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CorrectiveAction = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineDowntime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MachineDowntime_DowntimeReasons_DowntimeReasonId",
                        column: x => x.DowntimeReasonId,
                        principalTable: "DowntimeReasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachineDowntime_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MachineDowntime_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductionOrders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PartNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PartName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    CustomerName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    DrawingNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DrawingRevision = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    GlassTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    CncProgramId = table.Column<long>(type: "INTEGER", nullable: true),
                    PlannedQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProducedQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    GoodQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    RejectedQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlannedEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ActualStart = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_CncPrograms_CncProgramId",
                        column: x => x.CncProgramId,
                        principalTable: "CncPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_GlassTypes_GlassTypeId",
                        column: x => x.GlassTypeId,
                        principalTable: "GlassTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionOrders_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRuns",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductionOrderId = table.Column<long>(type: "INTEGER", nullable: false),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    OperatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    PieceNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Barcode = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CycleTimeSeconds = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsGood = table.Column<bool>(type: "INTEGER", nullable: false),
                    RejectionReason = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRuns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionRuns_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductionRuns_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ProductionRuns_ProductionOrders_ProductionOrderId",
                        column: x => x.ProductionOrderId,
                        principalTable: "ProductionOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CncProcessData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductionRunId = table.Column<long>(type: "INTEGER", nullable: false),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SpindleRpm = table.Column<decimal>(type: "TEXT", precision: 12, scale: 2, nullable: true),
                    FeedRate = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    SpindleLoad = table.Column<decimal>(type: "TEXT", precision: 8, scale: 3, nullable: true),
                    MotorCurrent = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: true),
                    XPosition = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    YPosition = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    ZPosition = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    CuttingDepth = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    CoolantPressure = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: true),
                    CoolantFlow = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: true),
                    CoolantTemperature = table.Column<decimal>(type: "TEXT", precision: 8, scale: 3, nullable: true),
                    AirPressure = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: true),
                    VacuumPressure = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: true),
                    MachineTemperature = table.Column<decimal>(type: "TEXT", precision: 8, scale: 3, nullable: true),
                    Vibration = table.Column<decimal>(type: "TEXT", precision: 10, scale: 3, nullable: true),
                    CycleTimeSeconds = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CncProcessData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CncProcessData_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CncProcessData_ProductionRuns_ProductionRunId",
                        column: x => x.ProductionRunId,
                        principalTable: "ProductionRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualityDefects",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductionRunId = table.Column<long>(type: "INTEGER", nullable: false),
                    DefectTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Severity = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    PhotoPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    DetectedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Disposition = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CorrectiveAction = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityDefects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityDefects_DefectTypes_DefectTypeId",
                        column: x => x.DefectTypeId,
                        principalTable: "DefectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityDefects_ProductionRuns_ProductionRunId",
                        column: x => x.ProductionRunId,
                        principalTable: "ProductionRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualityInspections",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductionRunId = table.Column<long>(type: "INTEGER", nullable: false),
                    OperatorId = table.Column<long>(type: "INTEGER", nullable: true),
                    InspectionTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InspectionType = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Result = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    InspectorName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    InspectionPhotoPath = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityInspections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityInspections_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_QualityInspections_ProductionRuns_ProductionRunId",
                        column: x => x.ProductionRunId,
                        principalTable: "ProductionRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToolUsages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ToolId = table.Column<long>(type: "INTEGER", nullable: false),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    ProductionRunId = table.Column<long>(type: "INTEGER", nullable: true),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PieceCount = table.Column<int>(type: "INTEGER", nullable: false),
                    UsageHours = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    RemainingLifePieces = table.Column<int>(type: "INTEGER", nullable: true),
                    RemainingLifeHours = table.Column<decimal>(type: "TEXT", precision: 12, scale: 3, nullable: true),
                    Condition = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToolUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToolUsages_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToolUsages_ProductionRuns_ProductionRunId",
                        column: x => x.ProductionRunId,
                        principalTable: "ProductionRuns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ToolUsages_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityMeasurements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QualityInspectionId = table.Column<long>(type: "INTEGER", nullable: false),
                    ParameterName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    ParameterCode = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    SpecificationNominal = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    LowerLimit = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: true),
                    UpperLimit = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: true),
                    ActualValue = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Deviation = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: true),
                    Unit = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    IsPassed = table.Column<bool>(type: "INTEGER", nullable: false),
                    MeasuringInstrument = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityMeasurements_QualityInspections_QualityInspectionId",
                        column: x => x.QualityInspectionId,
                        principalTable: "QualityInspections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CncProcessData_MachineId",
                table: "CncProcessData",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_CncProcessData_ProductionRunId",
                table: "CncProcessData",
                column: "ProductionRunId");

            migrationBuilder.CreateIndex(
                name: "IX_CncProcessData_Timestamp",
                table: "CncProcessData",
                column: "Timestamp");

            migrationBuilder.CreateIndex(
                name: "IX_CncPrograms_MachineId",
                table: "CncPrograms",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_CncPrograms_ProgramNumber_Revision",
                table: "CncPrograms",
                columns: new[] { "ProgramNumber", "Revision" });

            migrationBuilder.CreateIndex(
                name: "IX_DefectTypes_Code",
                table: "DefectTypes",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DowntimeReasons_Code",
                table: "DowntimeReasons",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GlassTypes_GlassCode",
                table: "GlassTypes",
                column: "GlassCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineAlarms_MachineId",
                table: "MachineAlarms",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineAlarms_StartTime",
                table: "MachineAlarms",
                column: "StartTime");

            migrationBuilder.CreateIndex(
                name: "IX_MachineDowntime_DowntimeReasonId",
                table: "MachineDowntime",
                column: "DowntimeReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineDowntime_MachineId",
                table: "MachineDowntime",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineDowntime_OperatorId",
                table: "MachineDowntime",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineDowntime_StartTime",
                table: "MachineDowntime",
                column: "StartTime");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_IPAddress",
                table: "Machines",
                column: "IPAddress");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineCode",
                table: "Machines",
                column: "MachineCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineTelemetry_MachineId_TagName_Timestamp",
                table: "MachineTelemetry",
                columns: new[] { "MachineId", "TagName", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_MachineTelemetry_MachineId_Timestamp",
                table: "MachineTelemetry",
                columns: new[] { "MachineId", "Timestamp" });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_MachineId",
                table: "MaintenanceRecords",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_NextDueDate",
                table: "MaintenanceRecords",
                column: "NextDueDate");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_StartTime",
                table: "MaintenanceRecords",
                column: "StartTime");

            migrationBuilder.CreateIndex(
                name: "IX_Operators_EmployeeCode",
                table: "Operators",
                column: "EmployeeCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_CncProgramId",
                table: "ProductionOrders",
                column: "CncProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_GlassTypeId",
                table: "ProductionOrders",
                column: "GlassTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_MachineId",
                table: "ProductionOrders",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionOrders_OrderNumber",
                table: "ProductionOrders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRuns_Barcode",
                table: "ProductionRuns",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRuns_MachineId",
                table: "ProductionRuns",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRuns_OperatorId",
                table: "ProductionRuns",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRuns_ProductionOrderId",
                table: "ProductionRuns",
                column: "ProductionOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRuns_StartTime",
                table: "ProductionRuns",
                column: "StartTime");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDefects_DefectTypeId",
                table: "QualityDefects",
                column: "DefectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDefects_DetectedAt",
                table: "QualityDefects",
                column: "DetectedAt");

            migrationBuilder.CreateIndex(
                name: "IX_QualityDefects_ProductionRunId",
                table: "QualityDefects",
                column: "ProductionRunId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityInspections_InspectionTime",
                table: "QualityInspections",
                column: "InspectionTime");

            migrationBuilder.CreateIndex(
                name: "IX_QualityInspections_OperatorId",
                table: "QualityInspections",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityInspections_ProductionRunId",
                table: "QualityInspections",
                column: "ProductionRunId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityMeasurements_QualityInspectionId",
                table: "QualityMeasurements",
                column: "QualityInspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tools_ToolCode",
                table: "Tools",
                column: "ToolCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToolUsages_MachineId",
                table: "ToolUsages",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolUsages_ProductionRunId",
                table: "ToolUsages",
                column: "ProductionRunId");

            migrationBuilder.CreateIndex(
                name: "IX_ToolUsages_StartTime",
                table: "ToolUsages",
                column: "StartTime");

            migrationBuilder.CreateIndex(
                name: "IX_ToolUsages_ToolId",
                table: "ToolUsages",
                column: "ToolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CncProcessData");

            migrationBuilder.DropTable(
                name: "MachineAlarms");

            migrationBuilder.DropTable(
                name: "MachineDowntime");

            migrationBuilder.DropTable(
                name: "MachineTelemetry");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "QualityDefects");

            migrationBuilder.DropTable(
                name: "QualityMeasurements");

            migrationBuilder.DropTable(
                name: "ToolUsages");

            migrationBuilder.DropTable(
                name: "DowntimeReasons");

            migrationBuilder.DropTable(
                name: "DefectTypes");

            migrationBuilder.DropTable(
                name: "QualityInspections");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "ProductionRuns");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "ProductionOrders");

            migrationBuilder.DropTable(
                name: "CncPrograms");

            migrationBuilder.DropTable(
                name: "GlassTypes");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
