using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet.WebMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImageForRegimen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Regimens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 14, 21, 25, 57, 867, DateTimeKind.Local).AddTicks(6229),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Regimens",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 14, 21, 25, 57, 867, DateTimeKind.Local).AddTicks(5422),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(1271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Foods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 14, 21, 25, 57, 867, DateTimeKind.Local).AddTicks(3898),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 219, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 14, 21, 25, 57, 867, DateTimeKind.Local).AddTicks(4593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(418));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Regimens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Regimens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(1996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 14, 21, 25, 57, 867, DateTimeKind.Local).AddTicks(6229));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(1271),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 14, 21, 25, 57, 867, DateTimeKind.Local).AddTicks(5422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Foods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 219, DateTimeKind.Local).AddTicks(9716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 14, 21, 25, 57, 867, DateTimeKind.Local).AddTicks(3898));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(418),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 14, 21, 25, 57, 867, DateTimeKind.Local).AddTicks(4593));
        }
    }
}
