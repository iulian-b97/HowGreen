using Microsoft.EntityFrameworkCore;
using Server.Entities.Consumption;
using Server.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data
{
    public class ConsumptionContext : DbContext
    {
        public ConsumptionContext(DbContextOptions<ConsumptionContext> options) : base(options)
        {

        }

        public DbSet<Appliance> Appliance { get; set; }
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
                .OnDelete(DeleteBehavior.Cascade);

            //SmallUser - FinalConsumption (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.FinalConsumptions)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Cascade);

            //SmallUser - EnergyLabel (one to many)
            modelBuilder.Entity<EnergyLabel>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.EnergyLabels)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Cascade);

            //FinalConsumption - Appliance (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey(y => y.FinalConsumptionId)
                .OnDelete(DeleteBehavior.Cascade);

            //FinalConsumption - EnergyLabel (one to one)
            modelBuilder.Entity<FinalConsumption>()
                .HasOne(x => x.EnergyLabel)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey<EnergyLabel>(y => y.FinalConsumptionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
