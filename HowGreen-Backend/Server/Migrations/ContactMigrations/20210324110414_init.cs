using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations.ContactMigrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmallUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CardType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumDonated = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donation_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinalConsumption",
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
                    table.PrimaryKey("PK_FinalConsumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinalConsumption_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerAdmins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerAdmins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerAdmins_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerAdmins_Contacts_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerProviders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerProviders_Contacts_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerProviders_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pay",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DonationId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CardOwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pay_Donation_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donation",
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
                        name: "FK_Appliance_FinalConsumption_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "FinalConsumption",
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
                        name: "FK_EnergyLabel_FinalConsumption_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "FinalConsumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnergyLabel_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusPayment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PayId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatusPayment_Pay_PayId",
                        column: x => x.PayId,
                        principalTable: "Pay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProviderId",
                table: "Addresses",
                column: "ProviderId",
                unique: true,
                filter: "[ProviderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAdmins_AdminId",
                table: "AnswerAdmins",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAdmins_MessageId",
                table: "AnswerAdmins",
                column: "MessageId",
                unique: true,
                filter: "[MessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerProviders_MessageId",
                table: "AnswerProviders",
                column: "MessageId",
                unique: true,
                filter: "[MessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerProviders_ProviderId",
                table: "AnswerProviders",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Appliance_FinalConsumptionId",
                table: "Appliance",
                column: "FinalConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appliance_SmallUserId",
                table: "Appliance",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_SmallUserId",
                table: "Contacts",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_SmallUserId",
                table: "Donation",
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

            migrationBuilder.CreateIndex(
                name: "IX_FinalConsumption_SmallUserId",
                table: "FinalConsumption",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_DonationId",
                table: "Pay",
                column: "DonationId",
                unique: true,
                filter: "[DonationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StatusPayment_PayId",
                table: "StatusPayment",
                column: "PayId",
                unique: true,
                filter: "[PayId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AnswerAdmins");

            migrationBuilder.DropTable(
                name: "AnswerProviders");

            migrationBuilder.DropTable(
                name: "Appliance");

            migrationBuilder.DropTable(
                name: "EnergyLabel");

            migrationBuilder.DropTable(
                name: "StatusPayment");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "FinalConsumption");

            migrationBuilder.DropTable(
                name: "Pay");

            migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropTable(
                name: "SmallUser");
        }
    }
}
