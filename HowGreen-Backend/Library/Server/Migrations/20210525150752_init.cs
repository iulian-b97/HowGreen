using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Server.Migrations
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IndexConsumptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexConsumptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndexConsumptions_SmallUser_SmallUserId",
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinalConsumptions",
                columns: table => new
                {
                    FinalConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nrKw = table.Column<float>(type: "real", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    IndexConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalConsumptions", x => x.FinalConsumptionId);
                    table.ForeignKey(
                        name: "FK_FinalConsumptions_IndexConsumptions_IndexConsumptionId",
                        column: x => x.IndexConsumptionId,
                        principalTable: "IndexConsumptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FinalConsumptions_SmallUser_SmallUserId",
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

            migrationBuilder.CreateTable(
                name: "Appliances",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplianceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nrWatts = table.Column<int>(type: "int", nullable: false),
                    hh = table.Column<int>(type: "int", nullable: false),
                    mm = table.Column<int>(type: "int", nullable: false),
                    priceKw = table.Column<float>(type: "real", nullable: false),
                    kwMonth = table.Column<float>(type: "real", nullable: false),
                    priceMonth = table.Column<float>(type: "real", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IndexConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FinalConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appliances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appliances_FinalConsumptions_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "FinalConsumptions",
                        principalColumn: "FinalConsumptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appliances_IndexConsumptions_IndexConsumptionId",
                        column: x => x.IndexConsumptionId,
                        principalTable: "IndexConsumptions",
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
                name: "EnergyLabelInputs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalConsumption = table.Column<float>(type: "real", nullable: false),
                    MP = table.Column<int>(type: "int", nullable: false),
                    TypeHouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLabelInputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyLabelInputs_FinalConsumptions_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "FinalConsumptions",
                        principalColumn: "FinalConsumptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnergyLabelInputs_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnergyLabelOutputs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EnergyClass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<float>(type: "real", nullable: false),
                    kW_mpa = table.Column<float>(type: "real", nullable: false),
                    TypeHouse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SmallUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FinalConsumptionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EnergyLabelInputId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLabelOutputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyLabelOutputs_EnergyLabelInputs_EnergyLabelInputId",
                        column: x => x.EnergyLabelInputId,
                        principalTable: "EnergyLabelInputs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnergyLabelOutputs_FinalConsumptions_FinalConsumptionId",
                        column: x => x.FinalConsumptionId,
                        principalTable: "FinalConsumptions",
                        principalColumn: "FinalConsumptionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnergyLabelOutputs_SmallUser_SmallUserId",
                        column: x => x.SmallUserId,
                        principalTable: "SmallUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Appliances_FinalConsumptionId",
                table: "Appliances",
                column: "FinalConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_IndexConsumptionId",
                table: "Appliances",
                column: "IndexConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appliances_SmallUserId",
                table: "Appliances",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_SmallUserId",
                table: "Donation",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabelInputs_FinalConsumptionId",
                table: "EnergyLabelInputs",
                column: "FinalConsumptionId",
                unique: true,
                filter: "[FinalConsumptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabelInputs_SmallUserId",
                table: "EnergyLabelInputs",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabelOutputs_EnergyLabelInputId",
                table: "EnergyLabelOutputs",
                column: "EnergyLabelInputId",
                unique: true,
                filter: "[EnergyLabelInputId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabelOutputs_FinalConsumptionId",
                table: "EnergyLabelOutputs",
                column: "FinalConsumptionId",
                unique: true,
                filter: "[FinalConsumptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLabelOutputs_SmallUserId",
                table: "EnergyLabelOutputs",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FinalConsumptions_IndexConsumptionId",
                table: "FinalConsumptions",
                column: "IndexConsumptionId",
                unique: true,
                filter: "[IndexConsumptionId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_FinalConsumptions_SmallUserId",
                table: "FinalConsumptions",
                column: "SmallUserId");

            migrationBuilder.CreateIndex(
                name: "IX_IndexConsumptions_SmallUserId",
                table: "IndexConsumptions",
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
                name: "Address");

            migrationBuilder.DropTable(
                name: "AnswerAdmin");

            migrationBuilder.DropTable(
                name: "AnswerProvider");

            migrationBuilder.DropTable(
                name: "Appliances");

            migrationBuilder.DropTable(
                name: "EnergyLabelOutputs");

            migrationBuilder.DropTable(
                name: "StatusPayment");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "EnergyLabelInputs");

            migrationBuilder.DropTable(
                name: "Pay");

            migrationBuilder.DropTable(
                name: "FinalConsumptions");

            migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropTable(
                name: "IndexConsumptions");

            migrationBuilder.DropTable(
                name: "SmallUser");
        }
    }
}
