using Library.Server.Entities.Contact;
using Library.Server.Entities.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Server.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<AnswerAdmin> AnswerAdmin { get; set; }
        public DbSet<AnswerProvider> AnswerProvider { get; set; }
        public DbSet<Provider> Provider { get; set; }
        public DbSet<Message> Contact { get; set; }
        public DbSet<Address> Address { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SmallUser - Message (one to many)
            modelBuilder.Entity<Message>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.Messages)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Message - AnswerAdmin (one to one)
            modelBuilder.Entity<AnswerAdmin>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.AnswerAdmin)
                .WithOne(y => y.Message)
                .HasForeignKey<AnswerAdmin>(y => y.MessageId)
                .OnDelete(DeleteBehavior.Restrict);

            //Message - AnswerProvider (one to one)
            modelBuilder.Entity<AnswerProvider>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.AnswerProvider)
                .WithOne(y => y.Message)
                .HasForeignKey<AnswerProvider>(y => y.MessageId)
                .OnDelete(DeleteBehavior.Restrict);

            //Admin - AnswerAdmin (one to many)
            modelBuilder.Entity<Admin>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Admin>()
                .HasMany(x => x.AnswerAdmins)
                .WithOne(y => y.Admin)
                .HasForeignKey(y => y.AdminId)
                .OnDelete(DeleteBehavior.Restrict);

            //Provider - AnswerProvider (one to many)
            modelBuilder.Entity<Provider>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Provider>()
                .HasMany(x => x.AnswerProviders)
                .WithOne(y => y.Provider)
                .HasForeignKey(y => y.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);

            //Provider - Address (one to one)
            modelBuilder.Entity<Address>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Provider>()
                .HasOne(x => x.Address)
                .WithOne(y => y.Provider)
                .HasForeignKey<Address>(y => y.ProviderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
