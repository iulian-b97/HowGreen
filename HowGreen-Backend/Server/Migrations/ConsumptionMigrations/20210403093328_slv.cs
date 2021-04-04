using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations.ConsumptionMigrations
{
    public partial class slv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appliances");

            migrationBuilder.DropTable(
                name: "EnergyLabels");

            migrationBuilder.DropTable(
                name: "Consumptions");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SmallUser",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SmallUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Consumption",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nrKw = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumption_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appliance",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FinalConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplianceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nrWatts = table.Column<int>(type: "int", nullable: false),
                    hoursDay = table.Column<int>(type: "int", nullable: false),
                    priceKw = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appliance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appliance_Consumption_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "Consumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appliance_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnergyLabel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FinalConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EnergyClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EfficientIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyLabel_Consumption_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "Consumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnergyLabel_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appliance_FinalConsumptionId",
                table: "Appliance",
                column: "FinalConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appliance_SmallUserId",
                table: "Appliance",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumption_SmallUserId",
                table: "Consumption",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabel_FinalConsumptionId",
                table: "EnergyLabel",
                column: "FinalConsumptionId",
                unique: true,
                filter: "[FinalConsumptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabel_SmallUserId",
                table: "EnergyLabel",
                column: "SmallUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appliance");

            migrationBuilder.DropTable(
                name: "EnergyLabel");

            migrationBuilder.DropTable(
                name: "Consumption");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SmallUser");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "SmallUser",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "Consumptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    nrKw = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumptions_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appliances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplianceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    hoursDay = table.Column<int>(type: "int", nullable: false),
                    nrWatts = table.Column<int>(type: "int", nullable: false),
                    priceKw = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appliances_Consumptions_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "Consumptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appliances_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnergyLabels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EfficientIndex = table.Column<int>(type: "int", nullable: false),
                    EnergyClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLabels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyLabels_Consumptions_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "Consumptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnergyLabels_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_FinalConsumptionId",
                table: "Appliances",
                column: "FinalConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_SmallUserId",
                table: "Appliances",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumptions_SmallUserId",
                table: "Consumptions",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabels_FinalConsumptionId",
                table: "EnergyLabels",
                column: "FinalConsumptionId",
                unique: true,
                filter: "[FinalConsumptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabels_SmallUserId",
                table: "EnergyLabels",
                column: "SmallUserId");
        }
    }
}
