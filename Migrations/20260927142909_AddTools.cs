using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AISSmartFactory.Migrations
{
    /// <inheritdoc />
    public partial class AddTools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ExpectedLifeHours",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ExpectedLifePieces",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "Tools");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tools",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ToolType",
                table: "Tools",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentLife",
                table: "Tools",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpectedLife",
                table: "Tools",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LifeUnit",
                table: "Tools",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "MaximumRpm",
                table: "Tools",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Specification",
                table: "Tools",
                type: "TEXT",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentLife",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "ExpectedLife",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "LifeUnit",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "MaximumRpm",
                table: "Tools");

            migrationBuilder.DropColumn(
                name: "Specification",
                table: "Tools");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Tools",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "ToolType",
                table: "Tools",
                type: "TEXT",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tools",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExpectedLifeHours",
                table: "Tools",
                type: "TEXT",
                precision: 12,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExpectedLifePieces",
                table: "Tools",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "Tools",
                type: "TEXT",
                maxLength: 100,
                nullable: true);
        }
    }
}
