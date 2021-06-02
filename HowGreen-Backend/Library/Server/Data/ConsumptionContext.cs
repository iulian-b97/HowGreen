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
        public DbSet<EnergyLabel> EnergyLabels { get; set; }
        public DbSet<IndexConsumption> IndexConsumptions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PK
            modelBuilder.Entity<IndexConsumption>()
                .HasKey(x => x.IndexConsumptionId);
            modelBuilder.Entity<FinalConsumption>()
                .HasKey(x => x.FinalConsumptionId);
            modelBuilder.Entity<Appliance>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<EnergyLabel>()
                .HasKey(x => x.Id);

            //SmallUser - IndexConsumption (one to many)
            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.IndexConsumptions)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //SmallUser - Appliance (one to many)
            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //SmallUser - FinalConsumption (one to many)
            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.FinalConsumptions)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //SmallUser - EnergyLabel (one to many)
            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.EnergyLabels)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //IndexConsumption - Appliance (one to many)
            modelBuilder.Entity<IndexConsumption>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.IndexConsumption)
                .HasForeignKey(y => y.IndexConsumptionId);

            //IndexConsumption - FinalConsumption (one to one)
            modelBuilder.Entity<IndexConsumption>()
                .HasOne(x => x.FinalConsumption)
                .WithOne(y => y.IndexConsumption)
                .HasForeignKey<FinalConsumption>(y => y.IndexConsumptionId);

            //FinalConsumption - Appliance (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey(y => y.FinalConsumptionId);

            //FinalConsumption - EnergyLabel(one to one)
            modelBuilder.Entity<FinalConsumption>()
                .HasOne(x => x.EnergyLabel)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey<EnergyLabel>(y => y.FinalConsumptionId);
        }
    }
}
