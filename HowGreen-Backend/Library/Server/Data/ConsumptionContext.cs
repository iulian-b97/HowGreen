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
        public DbSet<FinalConsumption> FinalConsumptions { get; set; }
        public DbSet<EnergyLabelInput> EnergyLabelInputs { get; set; }
        public DbSet<EnergyLabelOutput> EnergyLabelOutputs { get; set; }
        public DbSet<IndexConsumption> IndexConsumptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SmallUser - IndexConsumption (one to many)
            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.IndexConsumptions)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //IndexConsumption - Appliance (one to many)
            modelBuilder.Entity<IndexConsumption>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.IndexConsumption)
                .HasForeignKey(y => y.IndexConsumptionId);


            //FinalConsumption - Appliance (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey(y => y.FinalConsumptionId);

            //FinalConsumption - EnergyLabelInput (one to one)
            modelBuilder.Entity<FinalConsumption>()
                .HasOne(x => x.EnergyLabelInput)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey<EnergyLabelInput>(y => y.FinalConsumptionId);

            //EnergyLabelInput - EnergyLabelOutput (one to one)
            modelBuilder.Entity<EnergyLabelInput>()
                .HasOne(x => x.EnergyLabelOutput)
                .WithOne(y => y.EnergyLabelInput)
                .HasForeignKey<EnergyLabelOutput>(y => y.EnergyLabelInputId);
        }
    }
}
