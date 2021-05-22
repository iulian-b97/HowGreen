using Library.Server.Entities.Consumption;
using Library.Server.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Data
{
    public class ConsumptionContext : DbContext
    {
        public ConsumptionContext(DbContextOptions<ConsumptionContext> options) : base(options)
        {

        }

        public DbSet<Appliance> Appliance { get; set; }
        public DbSet<ApplianceConsumption> ApplianceConsumptions { get; set; }
        public DbSet<FinalConsumption> FinalConsumption { get; set; }
        public DbSet<EnergyLabel> EnergyLabel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SmallUser - Apliance (one to many)
            modelBuilder.Entity<Appliance>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //SmallUser - FinalConsumption (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.FinalConsumptions)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //SmallUser - EnergyLabel (one to many)
            modelBuilder.Entity<EnergyLabel>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.EnergyLabels)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Appliance - ApplianceConsumption (one to one)
            modelBuilder.Entity<Appliance>()
                .HasOne(x => x.ApplianceConsumption)
                .WithOne(y => y.Appliance)
                .HasForeignKey<ApplianceConsumption>(y => y.ApplianceId)
                .OnDelete(DeleteBehavior.Restrict);

            //FinalConsumption - Appliance (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey(y => y.FinalConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);

            //FinalConsumption - ApplianceConsumption (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasMany(x => x.ApplianceConsumptions)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey(y => y.FinalConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);

            //FinalConsumption - EnergyLabel (one to one)
            modelBuilder.Entity<FinalConsumption>()
                .HasOne(x => x.EnergyLabel)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey<EnergyLabel>(y => y.FinalConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
