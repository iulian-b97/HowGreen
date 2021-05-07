using Library.Server.Entities.Payment;
using Library.Server.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
        {

        }

        public DbSet<Pay> Pay { get; set; }
        public DbSet<Donation> Donation { get; set; }
        public DbSet<StatusPayment> StatusPayment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SmallUser - Donation (one to many)
            modelBuilder.Entity<Donation>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.Donations)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Cascade);

            //Donation - Pay (one to one)
            modelBuilder.Entity<Pay>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Donation>()
                .HasOne(x => x.Pay)
                .WithOne(y => y.Donation)
                .HasForeignKey<Pay>(y => y.DonationId)
                .OnDelete(DeleteBehavior.Cascade);

            //Pay - StatusPayment (one to one)
            modelBuilder.Entity<StatusPayment>()
                .HasKey(p => p.PayId);

            modelBuilder.Entity<Pay>()
                .HasOne(x => x.StatusPayment)
                .WithOne(y => y.Pay)
                .HasForeignKey<StatusPayment>(y => y.PayId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
