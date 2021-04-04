﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

namespace Server.Migrations.ConsumptionMigrations
{
    [DbContext(typeof(ConsumptionContext))]
    [Migration("20210403133745_SolvedBug")]
    partial class SolvedBug
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Server.Entities.Consumption.Appliance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplianceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalConsumptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("hoursDay")
                        .HasColumnType("int");

                    b.Property<int>("nrWatts")
                        .HasColumnType("int");

                    b.Property<int>("priceKw")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FinalConsumptionId");

                    b.HasIndex("SmallUserId");

                    b.ToTable("Appliance");
                });

            modelBuilder.Entity("Server.Entities.Consumption.EnergyLabel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EfficientIndex")
                        .HasColumnType("int");

                    b.Property<string>("EnergyClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalConsumptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FinalConsumptionId")
                        .IsUnique()
                        .HasFilter("[FinalConsumptionId] IS NOT NULL");

                    b.HasIndex("SmallUserId");

                    b.ToTable("EnergyLabel");
                });

            modelBuilder.Entity("Server.Entities.Consumption.FinalConsumption", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("nrKw")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("SmallUserId");

                    b.ToTable("Consumption");
                });

            modelBuilder.Entity("Server.Entities.Contact.Address", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId")
                        .IsUnique()
                        .HasFilter("[ProviderId] IS NOT NULL");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Server.Entities.Contact.Admin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Server.Entities.Contact.AnswerAdmin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("MessageId")
                        .IsUnique()
                        .HasFilter("[MessageId] IS NOT NULL");

                    b.ToTable("AnswerAdmin");
                });

            modelBuilder.Entity("Server.Entities.Contact.AnswerProvider", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Answer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MessageId")
                        .IsUnique()
                        .HasFilter("[MessageId] IS NOT NULL");

                    b.HasIndex("ProviderId");

                    b.ToTable("AnswerProvider");
                });

            modelBuilder.Entity("Server.Entities.Contact.Message", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MessageContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("SmallUserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("Server.Entities.Contact.Provider", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("Server.Entities.Payment.Donation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CardType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SumDonated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SmallUserId");

                    b.ToTable("Donation");
                });

            modelBuilder.Entity("Server.Entities.Payment.Pay", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardOwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DonationId")
                        .IsUnique()
                        .HasFilter("[DonationId] IS NOT NULL");

                    b.ToTable("Pay");
                });

            modelBuilder.Entity("Server.Entities.Payment.StatusPayment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PayId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PayId")
                        .IsUnique()
                        .HasFilter("[PayId] IS NOT NULL");

                    b.ToTable("StatusPayment");
                });

            modelBuilder.Entity("Server.Entities.User.SmallUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SmallUser");
                });

            modelBuilder.Entity("Server.Entities.Consumption.Appliance", b =>
                {
                    b.HasOne("Server.Entities.Consumption.FinalConsumption", "FinalConsumption")
                        .WithMany("Appliances")
                        .HasForeignKey("FinalConsumptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("Appliances")
                        .HasForeignKey("SmallUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FinalConsumption");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Server.Entities.Consumption.EnergyLabel", b =>
                {
                    b.HasOne("Server.Entities.Consumption.FinalConsumption", "FinalConsumption")
                        .WithOne("EnergyLabel")
                        .HasForeignKey("Server.Entities.Consumption.EnergyLabel", "FinalConsumptionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("EnergyLabels")
                        .HasForeignKey("SmallUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("FinalConsumption");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Server.Entities.Consumption.FinalConsumption", b =>
                {
                    b.HasOne("Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("FinalConsumptions")
                        .HasForeignKey("SmallUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Server.Entities.Contact.Address", b =>
                {
                    b.HasOne("Server.Entities.Contact.Provider", "Provider")
                        .WithOne("Address")
                        .HasForeignKey("Server.Entities.Contact.Address", "ProviderId");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Server.Entities.Contact.AnswerAdmin", b =>
                {
                    b.HasOne("Server.Entities.Contact.Admin", "Admin")
                        .WithMany("AnswerAdmins")
                        .HasForeignKey("AdminId");

                    b.HasOne("Server.Entities.Contact.Message", "Message")
                        .WithOne("AnswerAdmin")
                        .HasForeignKey("Server.Entities.Contact.AnswerAdmin", "MessageId");

                    b.Navigation("Admin");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Server.Entities.Contact.AnswerProvider", b =>
                {
                    b.HasOne("Server.Entities.Contact.Message", "Message")
                        .WithOne("AnswerProvider")
                        .HasForeignKey("Server.Entities.Contact.AnswerProvider", "MessageId");

                    b.HasOne("Server.Entities.Contact.Provider", "Provider")
                        .WithMany("AnswerProviders")
                        .HasForeignKey("ProviderId");

                    b.Navigation("Message");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Server.Entities.Contact.Message", b =>
                {
                    b.HasOne("Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("Messages")
                        .HasForeignKey("SmallUserId");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Server.Entities.Payment.Donation", b =>
                {
                    b.HasOne("Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("Donations")
                        .HasForeignKey("SmallUserId");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Server.Entities.Payment.Pay", b =>
                {
                    b.HasOne("Server.Entities.Payment.Donation", "Donation")
                        .WithOne("Pay")
                        .HasForeignKey("Server.Entities.Payment.Pay", "DonationId");

                    b.Navigation("Donation");
                });

            modelBuilder.Entity("Server.Entities.Payment.StatusPayment", b =>
                {
                    b.HasOne("Server.Entities.Payment.Pay", "Pay")
                        .WithOne("StatusPayment")
                        .HasForeignKey("Server.Entities.Payment.StatusPayment", "PayId");

                    b.Navigation("Pay");
                });

            modelBuilder.Entity("Server.Entities.Consumption.FinalConsumption", b =>
                {
                    b.Navigation("Appliances");

                    b.Navigation("EnergyLabel");
                });

            modelBuilder.Entity("Server.Entities.Contact.Admin", b =>
                {
                    b.Navigation("AnswerAdmins");
                });

            modelBuilder.Entity("Server.Entities.Contact.Message", b =>
                {
                    b.Navigation("AnswerAdmin");

                    b.Navigation("AnswerProvider");
                });

            modelBuilder.Entity("Server.Entities.Contact.Provider", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("AnswerProviders");
                });

            modelBuilder.Entity("Server.Entities.Payment.Donation", b =>
                {
                    b.Navigation("Pay");
                });

            modelBuilder.Entity("Server.Entities.Payment.Pay", b =>
                {
                    b.Navigation("StatusPayment");
                });

            modelBuilder.Entity("Server.Entities.User.SmallUser", b =>
                {
                    b.Navigation("Appliances");

                    b.Navigation("Donations");

                    b.Navigation("EnergyLabels");

                    b.Navigation("FinalConsumptions");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
