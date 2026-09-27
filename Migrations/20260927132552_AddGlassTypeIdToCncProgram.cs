using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AISSmartFactory.Migrations
{
    /// <inheritdoc />
    public partial class AddGlassTypeIdToCncProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "CncPrograms");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "CncPrograms");

            migrationBuilder.RenameColumn(
                name: "LastModifiedAt",
                table: "CncPrograms",
                newName: "TargetCycleTime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "CncPrograms",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GlassTypeId",
                table: "CncPrograms",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationType",
                table: "CncPrograms",
                type: "TEXT",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProgramCode",
                table: "CncPrograms",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CncPrograms_GlassTypeId",
                table: "CncPrograms",
                column: "GlassTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CncPrograms_GlassTypes_GlassTypeId",
                table: "CncPrograms",
                column: "GlassTypeId",
                principalTable: "GlassTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CncPrograms_GlassTypes_GlassTypeId",
                table: "CncPrograms");

            migrationBuilder.DropIndex(
                name: "IX_CncPrograms_GlassTypeId",
                table: "CncPrograms");

            migrationBuilder.DropColumn(
                name: "GlassTypeId",
                table: "CncPrograms");

            migrationBuilder.DropColumn(
                name: "OperationType",
                table: "CncPrograms");

            migrationBuilder.DropColumn(
                name: "ProgramCode",
                table: "CncPrograms");

            migrationBuilder.RenameColumn(
                name: "TargetCycleTime",
                table: "CncPrograms",
                newName: "LastModifiedAt");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "CncPrograms",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "CncPrograms",
                type: "TEXT",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "CncPrograms",
                type: "TEXT",
                maxLength: 500,
                nullable: true);
        }
    }
}
