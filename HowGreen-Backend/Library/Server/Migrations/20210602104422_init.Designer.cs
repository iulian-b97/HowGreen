﻿// <auto-generated />
using System;
using Library.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Server.Migrations
{
    [DbContext(typeof(ConsumptionContext))]
    [Migration("20210602104422_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Server.Entities.Consumption.Appliance", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplianceType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalConsumptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IndexConsumptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("hh")
                        .HasColumnType("int");

                    b.Property<float>("kwMonth")
                        .HasColumnType("real");

                    b.Property<int>("mm")
                        .HasColumnType("int");

                    b.Property<int>("nrWatts")
                        .HasColumnType("int");

                    b.Property<float>("priceMonth")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FinalConsumptionId");

                    b.HasIndex("IndexConsumptionId");

                    b.HasIndex("SmallUserId");

                    b.ToTable("Appliances");
                });

            modelBuilder.Entity("Library.Server.Entities.Consumption.EnergyLabel", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnergyClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinalConsumptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HouseType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Index")
                        .HasColumnType("real");

                    b.Property<int>("MP")
                        .HasColumnType("int");

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("TotalConsumption")
                        .HasColumnType("real");

                    b.Property<float>("kW_mpa")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FinalConsumptionId")
                        .IsUnique()
                        .HasFilter("[FinalConsumptionId] IS NOT NULL");

                    b.HasIndex("SmallUserId");

                    b.ToTable("EnergyLabels");
                });

            modelBuilder.Entity("Library.Server.Entities.Consumption.FinalConsumption", b =>
                {
                    b.Property<string>("FinalConsumptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IndexConsumptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("nrAppliances")
                        .HasColumnType("int");

                    b.Property<float>("nrKw")
                        .HasColumnType("real");

                    b.HasKey("FinalConsumptionId");

                    b.HasIndex("IndexConsumptionId")
                        .IsUnique()
                        .HasFilter("[IndexConsumptionId] IS NOT NULL");

                    b.HasIndex("SmallUserId");

                    b.ToTable("FinalConsumptions");
                });

            modelBuilder.Entity("Library.Server.Entities.Consumption.IndexConsumption", b =>
                {
                    b.Property<string>("IndexConsumptionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SmallUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("IndexConsumptionId");

                    b.HasIndex("SmallUserId");

                    b.ToTable("IndexConsumptions");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.Address", b =>
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

            modelBuilder.Entity("Library.Server.Entities.Contact.Admin", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.AnswerAdmin", b =>
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

            modelBuilder.Entity("Library.Server.Entities.Contact.AnswerProvider", b =>
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

            modelBuilder.Entity("Library.Server.Entities.Contact.Message", b =>
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

            modelBuilder.Entity("Library.Server.Entities.Contact.Provider", b =>
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

            modelBuilder.Entity("Library.Server.Entities.Payment.Donation", b =>
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

            modelBuilder.Entity("Library.Server.Entities.Payment.Pay", b =>
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

            modelBuilder.Entity("Library.Server.Entities.Payment.StatusPayment", b =>
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

            modelBuilder.Entity("Library.Server.Entities.User.SmallUser", b =>
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

            modelBuilder.Entity("Library.Server.Entities.Consumption.Appliance", b =>
                {
                    b.HasOne("Library.Server.Entities.Consumption.FinalConsumption", "FinalConsumption")
                        .WithMany("Appliances")
                        .HasForeignKey("FinalConsumptionId");

                    b.HasOne("Library.Server.Entities.Consumption.IndexConsumption", "IndexConsumption")
                        .WithMany("Appliances")
                        .HasForeignKey("IndexConsumptionId");

                    b.HasOne("Library.Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("Appliances")
                        .HasForeignKey("SmallUserId");

                    b.Navigation("FinalConsumption");

                    b.Navigation("IndexConsumption");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Library.Server.Entities.Consumption.EnergyLabel", b =>
                {
                    b.HasOne("Library.Server.Entities.Consumption.FinalConsumption", "FinalConsumption")
                        .WithOne("EnergyLabel")
                        .HasForeignKey("Library.Server.Entities.Consumption.EnergyLabel", "FinalConsumptionId");

                    b.HasOne("Library.Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("EnergyLabels")
                        .HasForeignKey("SmallUserId");

                    b.Navigation("FinalConsumption");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Library.Server.Entities.Consumption.FinalConsumption", b =>
                {
                    b.HasOne("Library.Server.Entities.Consumption.IndexConsumption", "IndexConsumption")
                        .WithOne("FinalConsumption")
                        .HasForeignKey("Library.Server.Entities.Consumption.FinalConsumption", "IndexConsumptionId");

                    b.HasOne("Library.Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("FinalConsumptions")
                        .HasForeignKey("SmallUserId");

                    b.Navigation("IndexConsumption");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Library.Server.Entities.Consumption.IndexConsumption", b =>
                {
                    b.HasOne("Library.Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("IndexConsumptions")
                        .HasForeignKey("SmallUserId");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.Address", b =>
                {
                    b.HasOne("Library.Server.Entities.Contact.Provider", "Provider")
                        .WithOne("Address")
                        .HasForeignKey("Library.Server.Entities.Contact.Address", "ProviderId");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.AnswerAdmin", b =>
                {
                    b.HasOne("Library.Server.Entities.Contact.Admin", "Admin")
                        .WithMany("AnswerAdmins")
                        .HasForeignKey("AdminId");

                    b.HasOne("Library.Server.Entities.Contact.Message", "Message")
                        .WithOne("AnswerAdmin")
                        .HasForeignKey("Library.Server.Entities.Contact.AnswerAdmin", "MessageId");

                    b.Navigation("Admin");

                    b.Navigation("Message");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.AnswerProvider", b =>
                {
                    b.HasOne("Library.Server.Entities.Contact.Message", "Message")
                        .WithOne("AnswerProvider")
                        .HasForeignKey("Library.Server.Entities.Contact.AnswerProvider", "MessageId");

                    b.HasOne("Library.Server.Entities.Contact.Provider", "Provider")
                        .WithMany("AnswerProviders")
                        .HasForeignKey("ProviderId");

                    b.Navigation("Message");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.Message", b =>
                {
                    b.HasOne("Library.Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("Messages")
                        .HasForeignKey("SmallUserId");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Library.Server.Entities.Payment.Donation", b =>
                {
                    b.HasOne("Library.Server.Entities.User.SmallUser", "SmallUser")
                        .WithMany("Donations")
                        .HasForeignKey("SmallUserId");

                    b.Navigation("SmallUser");
                });

            modelBuilder.Entity("Library.Server.Entities.Payment.Pay", b =>
                {
                    b.HasOne("Library.Server.Entities.Payment.Donation", "Donation")
                        .WithOne("Pay")
                        .HasForeignKey("Library.Server.Entities.Payment.Pay", "DonationId");

                    b.Navigation("Donation");
                });

            modelBuilder.Entity("Library.Server.Entities.Payment.StatusPayment", b =>
                {
                    b.HasOne("Library.Server.Entities.Payment.Pay", "Pay")
                        .WithOne("StatusPayment")
                        .HasForeignKey("Library.Server.Entities.Payment.StatusPayment", "PayId");

                    b.Navigation("Pay");
                });

            modelBuilder.Entity("Library.Server.Entities.Consumption.FinalConsumption", b =>
                {
                    b.Navigation("Appliances");

                    b.Navigation("EnergyLabel");
                });

            modelBuilder.Entity("Library.Server.Entities.Consumption.IndexConsumption", b =>
                {
                    b.Navigation("Appliances");

                    b.Navigation("FinalConsumption");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.Admin", b =>
                {
                    b.Navigation("AnswerAdmins");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.Message", b =>
                {
                    b.Navigation("AnswerAdmin");

                    b.Navigation("AnswerProvider");
                });

            modelBuilder.Entity("Library.Server.Entities.Contact.Provider", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("AnswerProviders");
                });

            modelBuilder.Entity("Library.Server.Entities.Payment.Donation", b =>
                {
                    b.Navigation("Pay");
                });

            modelBuilder.Entity("Library.Server.Entities.Payment.Pay", b =>
                {
                    b.Navigation("StatusPayment");
                });

            modelBuilder.Entity("Library.Server.Entities.User.SmallUser", b =>
                {
                    b.Navigation("Appliances");

                    b.Navigation("Donations");

                    b.Navigation("EnergyLabels");

                    b.Navigation("FinalConsumptions");

                    b.Navigation("IndexConsumptions");

                    b.Navigation("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
