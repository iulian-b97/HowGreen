using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations.ConsumptionMigrations
{
    public partial class UpdateFinalConsumtionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_Consumption_FinalConsumptionId",
                table: "Appliance");

            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_SmallUser_SmallUserId",
                table: "Appliance");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumption_SmallUser_SmallUserId",
                table: "Consumption");

            migrationBuilder.DropForeignKey(
                name: "FK_EnergyLabel_Consumption_FinalConsumptionId",
                table: "EnergyLabel");

            migrationBuilder.DropForeignKey(
                name: "FK_EnergyLabel_SmallUser_SmallUserId",
                table: "EnergyLabel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Consumption",
                table: "Consumption");

            migrationBuilder.RenameTable(
                name: "Consumption",
                newName: "FinalConsumption");

            migrationBuilder.RenameIndex(
                name: "IX_Consumption_SmallUserId",
                table: "FinalConsumption",
                newName: "IX_FinalConsumption_SmallUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FinalConsumption",
                table: "FinalConsumption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_FinalConsumption_FinalConsumptionId",
                table: "Appliance",
                column: "FinalConsumptionId",
                principalTable: "FinalConsumption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_SmallUser_SmallUserId",
                table: "Appliance",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnergyLabel_FinalConsumption_FinalConsumptionId",
                table: "EnergyLabel",
                column: "FinalConsumptionId",
                principalTable: "FinalConsumption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnergyLabel_SmallUser_SmallUserId",
                table: "EnergyLabel",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalConsumption_SmallUser_SmallUserId",
                table: "FinalConsumption",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_FinalConsumption_FinalConsumptionId",
                table: "Appliance");

            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_SmallUser_SmallUserId",
                table: "Appliance");

            migrationBuilder.DropForeignKey(
                name: "FK_EnergyLabel_FinalConsumption_FinalConsumptionId",
                table: "EnergyLabel");

            migrationBuilder.DropForeignKey(
                name: "FK_EnergyLabel_SmallUser_SmallUserId",
                table: "EnergyLabel");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalConsumption_SmallUser_SmallUserId",
                table: "FinalConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FinalConsumption",
                table: "FinalConsumption");

            migrationBuilder.RenameTable(
                name: "FinalConsumption",
                newName: "Consumption");

            migrationBuilder.RenameIndex(
                name: "IX_FinalConsumption_SmallUserId",
                table: "Consumption",
                newName: "IX_Consumption_SmallUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Consumption",
                table: "Consumption",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_Consumption_FinalConsumptionId",
                table: "Appliance",
                column: "FinalConsumptionId",
                principalTable: "Consumption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_SmallUser_SmallUserId",
                table: "Appliance",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumption_SmallUser_SmallUserId",
                table: "Consumption",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnergyLabel_Consumption_FinalConsumptionId",
                table: "EnergyLabel",
                column: "FinalConsumptionId",
                principalTable: "Consumption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnergyLabel_SmallUser_SmallUserId",
                table: "EnergyLabel",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
