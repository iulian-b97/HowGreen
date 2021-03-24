using Microsoft.EntityFrameworkCore;
using Server.Models.Payment;
using Server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {

        }

        public DbSet<Pay> Payments { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<StatusPayment> StatusPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SmallUser - Donation (one to many)
            modelBuilder.Entity<Donation>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.Donations)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //Donation - Pay (one to one)
            modelBuilder.Entity<Pay>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Donation>()
                .HasOne(x => x.Pay)
                .WithOne(y => y.Donation)
                .HasForeignKey<Pay>(y => y.DonationId);

            //Pay - StatusPayment (one to one)
            modelBuilder.Entity<StatusPayment>()
                .HasKey(p => p.PayId);

            modelBuilder.Entity<Pay>()
                .HasOne(x => x.StatusPayment)
                .WithOne(y => y.Pay)
                .HasForeignKey<StatusPayment>(y => y.PayId);
        }
    }
}
