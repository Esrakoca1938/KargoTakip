using System.Diagnostics;
using System.Text.RegularExpressions;
using KargoTakip.Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace KargoTakip.DAL.EntityFramework
{
    public class KargoTakipContext : DbContext
    {
		public KargoTakipContext() : base()
        {
            
        }

        public KargoTakipContext(DbContextOptions<KargoTakipContext> options) : base(options)
        {
            
        }
        
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=KargoTakipDB;Trusted_Connection=True;");
			}
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kargo>()
                .HasOne(r => r.TeslimAlanPersonel)
                .WithMany(r=>r.TeslimAlinanKargolar)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Kargo>()
                .HasOne(r => r.TeslimEdenPersonel)
                .WithMany(r=>r.TeslimEdilenKargolar)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Kargo>()
                .HasOne(r => r.GonderenMusteri)
                .WithMany(r=>r.GonderdigiKargolar)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Kargo>()
                .HasOne(r => r.AliciMusteri)
                .WithMany(r=>r.AldigiKargolar)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Kargo>()
                .HasOne(r => r.GonderenSube)
                .WithMany(r=>r.GonderenSubeKargolari)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Kargo>()
                .HasOne(r => r.AliciSube)
                .WithMany(r=>r.AliciSubeKargolari)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Musteri>()
                .HasMany(r => r.AldigiKargolar)
                .WithOne(r=>r.AliciMusteri)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Musteri>()
                .HasMany(r => r.GonderdigiKargolar)
                .WithOne(r=>r.GonderenMusteri)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<Personel>? Personeller { get; set; }
        public DbSet<Kargo>? Kargolar { get; set; }
        public DbSet<KargoDetay>? KargoDetaylar { get; set; }
        public DbSet<IslemTuru>? IslemTurleri{ get; set; }
        public DbSet<Ilce>? Ilceler { get; set; }
        public DbSet<Adres>? Adresler { get; set; }
        public DbSet<Musteri>? Musteriler { get; set; }
        public DbSet<Sehir>? Sehirler { get; set; }
        public DbSet<Sube>? Subeler { get; set; }
        public DbSet<Ucret>? Ucretler { get; set; }

    }
}
