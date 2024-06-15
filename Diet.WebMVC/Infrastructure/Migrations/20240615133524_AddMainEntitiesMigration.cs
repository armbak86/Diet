using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diet.WebMVC.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMainEntitiesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Exercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Minutes = table.Column<int>(type: "int", nullable: false),
                    BurnedCalorie = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 15, 17, 5, 22, 452, DateTimeKind.Local).AddTicks(9375))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PerAmount = table.Column<float>(type: "real", nullable: false),
                    Calorie = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 15, 17, 5, 22, 452, DateTimeKind.Local).AddTicks(8697))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 15, 17, 5, 22, 453, DateTimeKind.Local).AddTicks(110))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Regimens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 6, 15, 17, 5, 22, 453, DateTimeKind.Local).AddTicks(739))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regimens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoryExerciseItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoneExerciseAmount = table.Column<float>(type: "real", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    HistoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryExerciseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryExerciseItems_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryExerciseItems_Histories_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Histories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoryFoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EatenFoodAmount = table.Column<float>(type: "real", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    HistoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryFoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoryFoodItems_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoryFoodItems_Histories_HistoryId",
                        column: x => x.HistoryId,
                        principalTable: "Histories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_HistoryExerciseItems_ExerciseId",
                table: "HistoryExerciseItems",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryExerciseItems_HistoryId",
                table: "HistoryExerciseItems",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryFoodItems_FoodId",
                table: "HistoryFoodItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryFoodItems_HistoryId",
                table: "HistoryFoodItems",
                column: "HistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryRegimen_RegimensId",
                table: "HistoryRegimen",
                column: "RegimensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoryExerciseItems");

            migrationBuilder.DropTable(
                name: "HistoryFoodItems");

            migrationBuilder.DropTable(
                name: "HistoryRegimen");

            migrationBuilder.DropTable(
                name: "Exercises");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Regimens");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
