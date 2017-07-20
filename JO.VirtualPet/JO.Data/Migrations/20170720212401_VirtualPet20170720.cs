using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JO.Data.Migrations
{
    public partial class VirtualPet20170720 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalMetrics",
                columns: table => new
                {
                    AnimalMetricId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HappinessDecreaseRate = table.Column<float>(type: "REAL", nullable: false),
                    HappinessIncreaseRate = table.Column<float>(type: "REAL", nullable: false),
                    HungerDecreaseRate = table.Column<float>(type: "REAL", nullable: false),
                    HungerIncreaseRate = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalMetrics", x => x.AnimalMetricId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentHappiness = table.Column<float>(type: "REAL", nullable: false),
                    CurrentHunger = table.Column<float>(type: "REAL", nullable: false),
                    MetricAnimalMetricId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalMetrics_MetricAnimalMetricId",
                        column: x => x.MetricAnimalMetricId,
                        principalTable: "AnimalMetrics",
                        principalColumn: "AnimalMetricId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    AnimalTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MetricId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.AnimalTypeId);
                    table.ForeignKey(
                        name: "FK_AnimalTypes_AnimalMetrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "AnimalMetrics",
                        principalColumn: "AnimalMetricId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOwnedAnimals",
                columns: table => new
                {
                    UserOwnedAnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOwnedAnimals", x => x.UserOwnedAnimalId);
                    table.ForeignKey(
                        name: "FK_UserOwnedAnimals_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOwnedAnimals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_MetricAnimalMetricId",
                table: "Animals",
                column: "MetricAnimalMetricId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTypes_MetricId",
                table: "AnimalTypes",
                column: "MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOwnedAnimals_AnimalId",
                table: "UserOwnedAnimals",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOwnedAnimals_UserId",
                table: "UserOwnedAnimals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropTable(
                name: "UserOwnedAnimals");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AnimalMetrics");
        }
    }
}
