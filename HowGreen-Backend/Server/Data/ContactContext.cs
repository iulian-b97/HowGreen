using Microsoft.EntityFrameworkCore;
using Server.Models.Contact;
using Server.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AnswerAdmin> AnswerAdmins { get; set; }
        public DbSet<AnswerProvider> AnswerProviders { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Message> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SmallUser - Message (one to many)
            modelBuilder.Entity<Message>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<SmallUser>()
                .HasMany(x => x.Messages)
                .WithOne(y => y.SmallUser)
                .HasForeignKey(y => y.SmallUserId);

            //Message - AnswerAdmin (one to one)
            modelBuilder.Entity<AnswerAdmin>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.AnswerAdmin)
                .WithOne(y => y.Message)
                .HasForeignKey<AnswerAdmin>(y => y.MessageId);

            //Message - AnswerProvider (one to one)
            modelBuilder.Entity<AnswerProvider>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.AnswerProvider)
                .WithOne(y => y.Message)
                .HasForeignKey<AnswerProvider>(y => y.MessageId);

            //Admin - AnswerAdmin (one to many)
            modelBuilder.Entity<Admin>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Admin>()
                .HasMany(x => x.AnswerAdmins)
                .WithOne(y => y.Admin)
                .HasForeignKey(y => y.AdminId);

            //Provider - AnswerProvider (one to many)
            modelBuilder.Entity<Provider>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Provider>()
                .HasMany(x => x.AnswerProviders)
                .WithOne(y => y.Provider)
                .HasForeignKey(y => y.ProviderId);

            //Provider - Address (one to one)
            modelBuilder.Entity<Address>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Provider>()
                .HasOne(x => x.Address)
                .WithOne(y => y.Provider)
                .HasForeignKey<Address>(y => y.ProviderId);
        }
    }
}
