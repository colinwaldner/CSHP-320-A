using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactDB
{
    public partial class ContactsContext : DbContext
    {
        public ContactsContext()
        {
        }

        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {optionsBuilder.UseSqlServer("Data Source=COLIN-PC\\SQLEXPRESS;Initial Catalog=Contacts;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.ContactCreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ContactEmail).HasMaxLength(50);

                entity.Property(e => e.ContactName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ContactNotes).HasMaxLength(1000);

                entity.Property(e => e.ContactPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.ContactPhoneType).HasMaxLength(50);
            });
        }
    }
}
