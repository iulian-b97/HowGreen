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

        public DbSet<Appliance> Appliances { get; set; }
        public DbSet<ApplianceConsumption> ApplianceConsumptions { get; set; }
        public DbSet<FinalConsumption> FinalConsumptions { get; set; }
        public DbSet<EnergyLabelInput> EnergyLabelInputs { get; set; }
        public DbSet<EnergyLabelOutput> EnergyLabelOutputs { get; set; }
        public DbSet<IndexConsumption> IndexConsumptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IndexConsumption PK
            modelBuilder.Entity<IndexConsumption>()
                .HasKey(x => x.Id);


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
                .HasKey(p => p.IndexConsumptionId);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.FinalConsumptions)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //SmallUser - EnergyLabelInput (one to many)
            modelBuilder.Entity<EnergyLabelInput>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.EnergyLabelInputs)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //SmallUser - EnergyLabelOutput (one to many)
            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.EnergyLabelOutputs)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //IndexConsumption - Appliance (one to many)
            modelBuilder.Entity<IndexConsumption>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.IndexConsumption)
                .HasForeignKey(y => y.IndexConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);

            //IndexConsumption - ApplianceConsumption (one to many)
            modelBuilder.Entity<IndexConsumption>()
                .HasMany(x => x.ApplianceConsumptions)
                .WithOne(y => y.IndexConsumption)
                .HasForeignKey(y => y.IndexConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);

            //IndexConsumption - FinalConsumption (one to one)
            modelBuilder.Entity<IndexConsumption>()
                .HasOne(x => x.FinalConsumption)
                .WithOne(y => y.IndexConsumption)
                .HasForeignKey<FinalConsumption>(y => y.IndexConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);

            //IndexConsumption - EnergyLabelInput (one to one)
            modelBuilder.Entity<IndexConsumption>()
                .HasOne(x => x.EnergyLabelInput)
                .WithOne(y => y.IndexConsumption)
                .HasForeignKey<EnergyLabelInput>(y => y.IndexConsumptionId)
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
                .HasForeignKey(y => y.IndexConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);

            //FinalConsumption - ApplianceConsumption (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasMany(x => x.ApplianceConsumptions)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey(y => y.IndexConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);

            //FinalConsumption - EnergyLabelInput (one to one)
            modelBuilder.Entity<FinalConsumption>()
                .HasOne(x => x.EnergyLabelInput)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey<EnergyLabelInput>(y => y.IndexConsumptionId)
                .OnDelete(DeleteBehavior.Restrict);

            //EnergyLabelInput - EnergyLabelOutput (one to one)
            modelBuilder.Entity<EnergyLabelInput>()
                .HasOne(x => x.EnergyLabelOutput)
                .WithOne(y => y.EnergyLabelInput)
                .HasForeignKey<EnergyLabelOutput>(y => y.EnergyLabelInputId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
