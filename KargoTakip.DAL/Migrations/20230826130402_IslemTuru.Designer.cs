﻿// <auto-generated />
using System;
using KargoTakip.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KargoTakip.DAL.Migrations
{
    [DbContext(typeof(KargoTakipContext))]
    [Migration("20230826130402_IslemTuru")]
    partial class IslemTuru
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KargoTakip.Entity.Models.Adres", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("AdresAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("Detay")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<int?>("IlceId")
                        .HasColumnType("int");

                    b.Property<string>("PostaKodu")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<int>("SehirId")
                        .HasColumnType("int");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.HasKey("ID");

                    b.HasIndex("IlceId");

                    b.HasIndex("SehirId");

                    b.ToTable("Adres");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Ilce", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<string>("IlceAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SehirId")
                        .HasColumnType("int");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("SehirId");

                    b.ToTable("Ilce");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.IslemTuru", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<string>("IslemTuruAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("IslemTuru");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Kargo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<int>("AliciMusteriId")
                        .HasColumnType("int");

                    b.Property<int>("AliciSubeId")
                        .HasColumnType("int");

                    b.Property<int?>("Durum")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<int>("GonderenMusteriId")
                        .HasColumnType("int");

                    b.Property<int>("GonderenSubeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<int?>("OdemeTuru")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("TahminiTeslimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("TakipNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("TeslimAlanPersonelId")
                        .HasColumnType("int");

                    b.Property<int?>("TeslimEdenPersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TeslimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("UcretId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AliciMusteriId");

                    b.HasIndex("AliciSubeId");

                    b.HasIndex("GonderenMusteriId");

                    b.HasIndex("GonderenSubeId");

                    b.HasIndex("TeslimAlanPersonelId");

                    b.HasIndex("TeslimEdenPersonelId");

                    b.HasIndex("UcretId");

                    b.ToTable("Kargo");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.KargoDetay", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<int?>("IslemTuru")
                        .HasColumnType("int");

                    b.Property<int?>("IslemTuruID")
                        .HasColumnType("int");

                    b.Property<int>("KargoId")
                        .HasColumnType("int");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.Property<int>("SubeId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IslemTuruID");

                    b.HasIndex("KargoId");

                    b.HasIndex("SubeId");

                    b.ToTable("KargoDetay");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Musteri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("AdresId")
                        .HasColumnType("int");

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<string>("KimlikNo")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.HasIndex("AdresId");

                    b.ToTable("Musteri");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Personel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("Cinsiyet")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<string>("KimlikNo")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Pozisyon")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Personel");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Sehir", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<string>("SehirAdi")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Sehir");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Sube", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AdresId")
                        .HasColumnType("int");

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.Property<string>("SubeAdi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.HasIndex("AdresId");

                    b.ToTable("Sube");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Ucret", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool?>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<string>("Buyukluk")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EkleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("GuncellenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GuncelleyenPersonelId")
                        .HasColumnType("int");

                    b.Property<bool?>("SilindiMi")
                        .HasColumnType("bit");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("Ucret");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Adres", b =>
                {
                    b.HasOne("KargoTakip.Entity.Models.Ilce", "Ilce")
                        .WithMany("Adresler")
                        .HasForeignKey("IlceId");

                    b.HasOne("KargoTakip.Entity.Models.Sehir", "Sehir")
                        .WithMany("Adresler")
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ilce");

                    b.Navigation("Sehir");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Ilce", b =>
                {
                    b.HasOne("KargoTakip.Entity.Models.Sehir", "Sehir")
                        .WithMany("Ilceler")
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sehir");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Kargo", b =>
                {
                    b.HasOne("KargoTakip.Entity.Models.Musteri", "AliciMusteri")
                        .WithMany("AldigiKargolar")
                        .HasForeignKey("AliciMusteriId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KargoTakip.Entity.Models.Sube", "AliciSube")
                        .WithMany("AliciSubeKargolari")
                        .HasForeignKey("AliciSubeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KargoTakip.Entity.Models.Musteri", "GonderenMusteri")
                        .WithMany("GonderdigiKargolar")
                        .HasForeignKey("GonderenMusteriId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KargoTakip.Entity.Models.Sube", "GonderenSube")
                        .WithMany("GonderenSubeKargolari")
                        .HasForeignKey("GonderenSubeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KargoTakip.Entity.Models.Personel", "TeslimAlanPersonel")
                        .WithMany("TeslimAlinanKargolar")
                        .HasForeignKey("TeslimAlanPersonelId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("KargoTakip.Entity.Models.Personel", "TeslimEdenPersonel")
                        .WithMany("TeslimEdilenKargolar")
                        .HasForeignKey("TeslimEdenPersonelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("KargoTakip.Entity.Models.Ucret", "Ucret")
                        .WithMany("Kargolar")
                        .HasForeignKey("UcretId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AliciMusteri");

                    b.Navigation("AliciSube");

                    b.Navigation("GonderenMusteri");

                    b.Navigation("GonderenSube");

                    b.Navigation("TeslimAlanPersonel");

                    b.Navigation("TeslimEdenPersonel");

                    b.Navigation("Ucret");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.KargoDetay", b =>
                {
                    b.HasOne("KargoTakip.Entity.Models.IslemTuru", null)
                        .WithMany("KargoDetaylari")
                        .HasForeignKey("IslemTuruID");

                    b.HasOne("KargoTakip.Entity.Models.Kargo", "Kargo")
                        .WithMany("KargoDetaylari")
                        .HasForeignKey("KargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KargoTakip.Entity.Models.Sube", "Sube")
                        .WithMany("KargoDetaylari")
                        .HasForeignKey("SubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kargo");

                    b.Navigation("Sube");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Musteri", b =>
                {
                    b.HasOne("KargoTakip.Entity.Models.Adres", "Adres")
                        .WithMany("Musteriler")
                        .HasForeignKey("AdresId");

                    b.Navigation("Adres");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Sube", b =>
                {
                    b.HasOne("KargoTakip.Entity.Models.Adres", "Adres")
                        .WithMany("Subeler")
                        .HasForeignKey("AdresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adres");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Adres", b =>
                {
                    b.Navigation("Musteriler");

                    b.Navigation("Subeler");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Ilce", b =>
                {
                    b.Navigation("Adresler");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.IslemTuru", b =>
                {
                    b.Navigation("KargoDetaylari");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Kargo", b =>
                {
                    b.Navigation("KargoDetaylari");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Musteri", b =>
                {
                    b.Navigation("AldigiKargolar");

                    b.Navigation("GonderdigiKargolar");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Personel", b =>
                {
                    b.Navigation("TeslimAlinanKargolar");

                    b.Navigation("TeslimEdilenKargolar");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Sehir", b =>
                {
                    b.Navigation("Adresler");

                    b.Navigation("Ilceler");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Sube", b =>
                {
                    b.Navigation("AliciSubeKargolari");

                    b.Navigation("GonderenSubeKargolari");

                    b.Navigation("KargoDetaylari");
                });

            modelBuilder.Entity("KargoTakip.Entity.Models.Ucret", b =>
                {
                    b.Navigation("Kargolar");
                });
#pragma warning restore 612, 618
        }
    }
}
