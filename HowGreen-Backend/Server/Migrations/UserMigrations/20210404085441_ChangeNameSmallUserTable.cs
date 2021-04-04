using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations.UserMigrations
{
    public partial class ChangeNameSmallUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_Users_SmallUserId",
                table: "Appliance");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Users_SmallUserId",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_EnergyLabel_Users_SmallUserId",
                table: "EnergyLabel");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalConsumption_Users_SmallUserId",
                table: "FinalConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_Users_SmallUserId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "SmallUser");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SmallUser",
                table: "SmallUser",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_SmallUser_SmallUserId",
                table: "Appliance",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_SmallUser_SmallUserId",
                table: "Donation",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnergyLabel_SmallUser_SmallUserId",
                table: "EnergyLabel",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalConsumption_SmallUser_SmallUserId",
                table: "FinalConsumption",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_SmallUser_SmallUserId",
                table: "Message",
                column: "SmallUserId",
                principalTable: "SmallUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appliance_SmallUser_SmallUserId",
                table: "Appliance");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_SmallUser_SmallUserId",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_EnergyLabel_SmallUser_SmallUserId",
                table: "EnergyLabel");

            migrationBuilder.DropForeignKey(
                name: "FK_FinalConsumption_SmallUser_SmallUserId",
                table: "FinalConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Message_SmallUser_SmallUserId",
                table: "Message");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SmallUser",
                table: "SmallUser");

            migrationBuilder.RenameTable(
                name: "SmallUser",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appliance_Users_SmallUserId",
                table: "Appliance",
                column: "SmallUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Users_SmallUserId",
                table: "Donation",
                column: "SmallUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EnergyLabel_Users_SmallUserId",
                table: "EnergyLabel",
                column: "SmallUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinalConsumption_Users_SmallUserId",
                table: "FinalConsumption",
                column: "SmallUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Users_SmallUserId",
                table: "Message",
                column: "SmallUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
