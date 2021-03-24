using Microsoft.EntityFrameworkCore;
using Server.Models.Consumption;
using Server.Models.User;
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

        public DbSet<Appliance> Appliances { get; set; }
        public DbSet<FinalConsumption> Consumptions { get; set; }
        public DbSet<EnergyLabel> EnergyLabels { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SmallUser - Apliance (one to many)
            modelBuilder.Entity<Appliance>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //SmallUser - FinalConsumption (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.FinalConsumptions)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //SmallUser - EnergyLabel (one to many)
            modelBuilder.Entity<EnergyLabel>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.EnergyLabels)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //FinalConsumption - Appliance (one to many)
            modelBuilder.Entity<FinalConsumption>()
                .HasMany(x => x.Appliances)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey(y => y.FinalConsumptionId);

            //FinalConsumption - EnergyLabel (one to one)
            modelBuilder.Entity<FinalConsumption>()
                .HasOne(x => x.EnergyLabel)
                .WithOne(y => y.FinalConsumption)
                .HasForeignKey<EnergyLabel>(y => y.FinalConsumptionId);
        }
    }
}
