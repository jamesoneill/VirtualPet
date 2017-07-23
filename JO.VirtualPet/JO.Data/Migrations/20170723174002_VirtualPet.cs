using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JO.Data.Migrations
{
    public partial class VirtualPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalStats",
                columns: table => new
                {
                    AnimalStatsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HappinessDecreaseRate = table.Column<double>(type: "REAL", nullable: false),
                    HappinessIncreaseRate = table.Column<double>(type: "REAL", nullable: false),
                    HappinessTickRate = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HungerDecreaseRate = table.Column<double>(type: "REAL", nullable: false),
                    HungerIncreaseRate = table.Column<double>(type: "REAL", nullable: false),
                    HungerTickRate = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    MaxHappiness = table.Column<double>(type: "REAL", nullable: false),
                    MaxHunger = table.Column<double>(type: "REAL", nullable: false),
                    MinHappiness = table.Column<double>(type: "REAL", nullable: false),
                    MinHunger = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalStats", x => x.AnimalStatsId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    AnimalTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalStatId = table.Column<int>(type: "INTEGER", nullable: true),
                    StatsAnimalStatsId = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.AnimalTypeId);
                    table.ForeignKey(
                        name: "FK_AnimalTypes_AnimalStats_StatsAnimalStatsId",
                        column: x => x.StatsAnimalStatsId,
                        principalTable: "AnimalStats",
                        principalColumn: "AnimalStatsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnimalTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentHappiness = table.Column<double>(type: "REAL", nullable: false),
                    CurrentHunger = table.Column<double>(type: "REAL", nullable: false),
                    LastReCalculation = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "AnimalTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_AnimalTypeId",
                table: "Animals",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_UserId",
                table: "Animals",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalTypes_StatsAnimalStatsId",
                table: "AnimalTypes",
                column: "StatsAnimalStatsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AnimalStats");
        }
    }
}
