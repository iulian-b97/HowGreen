﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Server.Migrations.PaymentMigrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SmallUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmallUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
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
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
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
                        onDelete: ReferentialAction.Cascade);
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
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MessageContent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Message_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
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
                        onDelete: ReferentialAction.Cascade);
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
                    hh = table.Column<int>(type: "int", nullable: false),
                    mm = table.Column<int>(type: "int", nullable: false),
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
                name: "AnswerAdmin",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AdminId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerAdmin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerAdmin_Admin_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admin",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerAdmin_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnswerProvider",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MessageId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProviderId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerProvider_Message_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Message",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnswerProvider_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatusPayment",
                columns: table => new
                {
                    PayId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPayment", x => x.PayId);
                    table.ForeignKey(
                        name: "FK_StatusPayment_Pay_PayId",
                        column: x => x.PayId,
                        principalTable: "Pay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ProviderId",
                table: "Address",
                column: "ProviderId",
                unique: true,
                filter: "[ProviderId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAdmin_AdminId",
                table: "AnswerAdmin",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerAdmin_MessageId",
                table: "AnswerAdmin",
                column: "MessageId",
                unique: true,
                filter: "[MessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerProvider_MessageId",
                table: "AnswerProvider",
                column: "MessageId",
                unique: true,
                filter: "[MessageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerProvider_ProviderId",
                table: "AnswerProvider",
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
                name: "IX_Message_SmallUserId",
                table: "Message",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pay_DonationId",
                table: "Pay",
                column: "DonationId",
                unique: true,
                filter: "[DonationId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AnswerAdmin");

            migrationBuilder.DropTable(
                name: "AnswerProvider");

            migrationBuilder.DropTable(
                name: "Appliance");

            migrationBuilder.DropTable(
                name: "EnergyLabel");

            migrationBuilder.DropTable(
                name: "StatusPayment");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Provider");

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