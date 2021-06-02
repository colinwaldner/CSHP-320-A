using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CryptoWalletDB
{
    public partial class CryptoWalletContext : DbContext
    {
        public CryptoWalletContext()
        {
        }

        public CryptoWalletContext(DbContextOptions<CryptoWalletContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coin> Coin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=COLIN-PC\\SQLEXPRESS;Initial Catalog=CryptoWallet;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coin>(entity =>
            {
                entity.Property(e => e.CurrentPrice).HasColumnType("money");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PurchasePrice).HasColumnType("money");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Ticker)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
