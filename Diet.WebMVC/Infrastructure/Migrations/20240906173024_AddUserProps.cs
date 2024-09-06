using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet.WebMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Histories_AspNetUsers_AppUserId",
                table: "Histories");

            migrationBuilder.DropTable(
                name: "HistoryRegimen");

            migrationBuilder.DropIndex(
                name: "IX_Histories_AppUserId",
                table: "Histories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Regimens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 6, 21, 0, 23, 347, DateTimeKind.Local).AddTicks(7313),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 4, 13, 0, 30, 410, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Regimens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 6, 21, 0, 23, 346, DateTimeKind.Local).AddTicks(6708),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 4, 13, 0, 30, 410, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Histories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Foods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 6, 21, 0, 23, 346, DateTimeKind.Local).AddTicks(4796),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 4, 13, 0, 30, 410, DateTimeKind.Local).AddTicks(1717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 9, 6, 21, 0, 23, 346, DateTimeKind.Local).AddTicks(5549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 8, 4, 13, 0, 30, 410, DateTimeKind.Local).AddTicks(2588));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Hight",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "HistoryId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "AspNetUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "AppUserRegimen",
                columns: table => new
                {
                    AppUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegimensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRegimen", x => new { x.AppUsersId, x.RegimensId });
                    table.ForeignKey(
                        name: "FK_AppUserRegimen_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppUserRegimen_Regimens_RegimensId",
                        column: x => x.RegimensId,
                        principalTable: "Regimens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HistoryId",
                table: "AspNetUsers",
                column: "HistoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AppUserRegimen_RegimensId",
                table: "AppUserRegimen",
                column: "RegimensId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Histories_HistoryId",
                table: "AspNetUsers",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Histories_HistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "AppUserRegimen");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Regimens");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Hight",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Regimens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 4, 13, 0, 30, 410, DateTimeKind.Local).AddTicks(4274),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 6, 21, 0, 23, 347, DateTimeKind.Local).AddTicks(7313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Histories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 4, 13, 0, 30, 410, DateTimeKind.Local).AddTicks(3490),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 6, 21, 0, 23, 346, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Histories",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Foods",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 4, 13, 0, 30, 410, DateTimeKind.Local).AddTicks(1717),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 6, 21, 0, 23, 346, DateTimeKind.Local).AddTicks(4796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Exercises",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 8, 4, 13, 0, 30, 410, DateTimeKind.Local).AddTicks(2588),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 9, 6, 21, 0, 23, 346, DateTimeKind.Local).AddTicks(5549));

            migrationBuilder.CreateTable(
                name: "HistoryRegimen",
                columns: table => new
                {
                    HistoriesId = table.Column<int>(type: "int", nullable: false),
                    RegimensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryRegimen", x => new { x.HistoriesId, x.RegimensId });
                    table.ForeignKey(
                        name: "FK_HistoryRegimen_Histories_HistoriesId",
                        column: x => x.HistoriesId,
                        principalTable: "Histories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryRegimen_Regimens_RegimensId",
                        column: x => x.RegimensId,
                        principalTable: "Regimens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_AppUserId",
                table: "Histories",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryRegimen_RegimensId",
                table: "HistoryRegimen",
                column: "RegimensId");

            migrationBuilder.AddForeignKey(
                name: "FK_Histories_AspNetUsers_AppUserId",
                table: "Histories",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
