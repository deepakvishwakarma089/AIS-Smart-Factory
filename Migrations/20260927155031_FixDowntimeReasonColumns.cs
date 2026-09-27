using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AISSmartFactory.Migrations
{
    /// <inheritdoc />
    public partial class FixDowntimeReasonColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "DowntimeReasons",
                newName: "ReasonName");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "DowntimeReasons",
                newName: "ReasonCode");

            migrationBuilder.RenameIndex(
                name: "IX_DowntimeReasons_Code",
                table: "DowntimeReasons",
                newName: "IX_DowntimeReasons_ReasonCode");

            migrationBuilder.AddColumn<bool>(
                name: "RequiresComment",
                table: "DowntimeReasons",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CncProductionEntries",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductionNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MachineId = table.Column<long>(type: "INTEGER", nullable: false),
                    OperatorId = table.Column<long>(type: "INTEGER", nullable: false),
                    GlassTypeId = table.Column<long>(type: "INTEGER", nullable: false),
                    CncProgramId = table.Column<long>(type: "INTEGER", nullable: false),
                    ToolId = table.Column<long>(type: "INTEGER", nullable: true),
                    PlannedQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    ProducedQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    GoodQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    RejectedQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    CycleTimeSeconds = table.Column<decimal>(type: "TEXT", nullable: true),
                    SpindleRpm = table.Column<decimal>(type: "TEXT", nullable: true),
                    FeedRate = table.Column<decimal>(type: "TEXT", nullable: true),
                    CuttingDepth = table.Column<decimal>(type: "TEXT", nullable: true),
                    CoolantPressure = table.Column<decimal>(type: "TEXT", nullable: true),
                    AirPressure = table.Column<decimal>(type: "TEXT", nullable: true),
                    MachineLoadPercent = table.Column<decimal>(type: "TEXT", nullable: true),
                    EnergyKwh = table.Column<decimal>(type: "TEXT", nullable: true),
                    QualityApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    QualityRemarks = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Remarks = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CncProductionEntries", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CncProductionEntries");

            migrationBuilder.DropColumn(
                name: "RequiresComment",
                table: "DowntimeReasons");

            migrationBuilder.RenameColumn(
                name: "ReasonName",
                table: "DowntimeReasons",
                newName: "Reason");

            migrationBuilder.RenameColumn(
                name: "ReasonCode",
                table: "DowntimeReasons",
                newName: "Code");

            migrationBuilder.RenameIndex(
                name: "IX_DowntimeReasons_ReasonCode",
                table: "DowntimeReasons",
                newName: "IX_DowntimeReasons_Code");
        }
    }
}
