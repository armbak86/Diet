using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet.WebMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAppUserIdFromRegimen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Regimens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Regimens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(1996),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 9, 1, 17, 12, 190, DateTimeKind.Local).AddTicks(9484));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(1271),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 9, 1, 17, 12, 190, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Foods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 219, DateTimeKind.Local).AddTicks(9716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 9, 1, 17, 12, 190, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(418),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 9, 1, 17, 12, 190, DateTimeKind.Local).AddTicks(6757));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Regimens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 9, 1, 17, 12, 190, DateTimeKind.Local).AddTicks(9484),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(1996));

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Regimens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 9, 1, 17, 12, 190, DateTimeKind.Local).AddTicks(8284),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(1271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Foods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 9, 1, 17, 12, 190, DateTimeKind.Local).AddTicks(5357),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 219, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 9, 1, 17, 12, 190, DateTimeKind.Local).AddTicks(6757),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 12, 0, 23, 6, 220, DateTimeKind.Local).AddTicks(418));
        }
    }
}
