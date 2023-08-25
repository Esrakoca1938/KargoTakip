using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargoTakip.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IslemTuru",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IslemTuruAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslemTuru", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personel",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Pozisyon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sehir",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehir", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ucret",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyukluk = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ucret", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ilce",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IlceAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SehirId = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilce", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ilce_Sehir_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehir",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adres",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdresAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SehirId = table.Column<int>(type: "int", nullable: false),
                    IlceId = table.Column<int>(type: "int", nullable: true),
                    Detay = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PostaKodu = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adres", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adres_Ilce_IlceId",
                        column: x => x.IlceId,
                        principalTable: "Ilce",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Adres_Sehir_SehirId",
                        column: x => x.SehirId,
                        principalTable: "Sehir",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musteri",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KimlikNo = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: true),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteri", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Musteri_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Sube",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubeAdi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdresId = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sube", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Sube_Adres_AdresId",
                        column: x => x.AdresId,
                        principalTable: "Adres",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kargo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TakipNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GonderenMusteriId = table.Column<int>(type: "int", nullable: false),
                    AliciMusteriId = table.Column<int>(type: "int", nullable: false),
                    GonderenSubeId = table.Column<int>(type: "int", nullable: false),
                    AliciSubeId = table.Column<int>(type: "int", nullable: false),
                    TeslimAlanPersonelId = table.Column<int>(type: "int", nullable: false),
                    TeslimEdenPersonelId = table.Column<int>(type: "int", nullable: false),
                    UcretId = table.Column<int>(type: "int", nullable: false),
                    OdemeTuru = table.Column<int>(type: "int", nullable: false),
                    TahminiTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kargo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Kargo_Musteri_AliciMusteriId",
                        column: x => x.AliciMusteriId,
                        principalTable: "Musteri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kargo_Musteri_GonderenMusteriId",
                        column: x => x.GonderenMusteriId,
                        principalTable: "Musteri",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kargo_Personel_TeslimAlanPersonelId",
                        column: x => x.TeslimAlanPersonelId,
                        principalTable: "Personel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kargo_Personel_TeslimEdenPersonelId",
                        column: x => x.TeslimEdenPersonelId,
                        principalTable: "Personel",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kargo_Sube_AliciSubeId",
                        column: x => x.AliciSubeId,
                        principalTable: "Sube",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kargo_Sube_GonderenSubeId",
                        column: x => x.GonderenSubeId,
                        principalTable: "Sube",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Kargo_Ucret_UcretId",
                        column: x => x.UcretId,
                        principalTable: "Ucret",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KargoDetay",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KargoId = table.Column<int>(type: "int", nullable: false),
                    SubeId = table.Column<int>(type: "int", nullable: false),
                    IslemTuruId = table.Column<int>(type: "int", nullable: false),
                    SilindiMi = table.Column<bool>(type: "bit", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: true),
                    EkleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    GuncelleyenPersonelId = table.Column<int>(type: "int", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuncellenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KargoDetay", x => x.ID);
                    table.ForeignKey(
                        name: "FK_KargoDetay_IslemTuru_IslemTuruId",
                        column: x => x.IslemTuruId,
                        principalTable: "IslemTuru",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KargoDetay_Kargo_KargoId",
                        column: x => x.KargoId,
                        principalTable: "Kargo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KargoDetay_Sube_SubeId",
                        column: x => x.SubeId,
                        principalTable: "Sube",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adres_IlceId",
                table: "Adres",
                column: "IlceId");

            migrationBuilder.CreateIndex(
                name: "IX_Adres_SehirId",
                table: "Adres",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Ilce_SehirId",
                table: "Ilce",
                column: "SehirId");

            migrationBuilder.CreateIndex(
                name: "IX_Kargo_AliciMusteriId",
                table: "Kargo",
                column: "AliciMusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Kargo_AliciSubeId",
                table: "Kargo",
                column: "AliciSubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kargo_GonderenMusteriId",
                table: "Kargo",
                column: "GonderenMusteriId");

            migrationBuilder.CreateIndex(
                name: "IX_Kargo_GonderenSubeId",
                table: "Kargo",
                column: "GonderenSubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Kargo_TeslimAlanPersonelId",
                table: "Kargo",
                column: "TeslimAlanPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Kargo_TeslimEdenPersonelId",
                table: "Kargo",
                column: "TeslimEdenPersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Kargo_UcretId",
                table: "Kargo",
                column: "UcretId");

            migrationBuilder.CreateIndex(
                name: "IX_KargoDetay_IslemTuruId",
                table: "KargoDetay",
                column: "IslemTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_KargoDetay_KargoId",
                table: "KargoDetay",
                column: "KargoId");

            migrationBuilder.CreateIndex(
                name: "IX_KargoDetay_SubeId",
                table: "KargoDetay",
                column: "SubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Musteri_AdresId",
                table: "Musteri",
                column: "AdresId");

            migrationBuilder.CreateIndex(
                name: "IX_Sube_AdresId",
                table: "Sube",
                column: "AdresId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KargoDetay");

            migrationBuilder.DropTable(
                name: "IslemTuru");

            migrationBuilder.DropTable(
                name: "Kargo");

            migrationBuilder.DropTable(
                name: "Musteri");

            migrationBuilder.DropTable(
                name: "Personel");

            migrationBuilder.DropTable(
                name: "Sube");

            migrationBuilder.DropTable(
                name: "Ucret");

            migrationBuilder.DropTable(
                name: "Adres");

            migrationBuilder.DropTable(
                name: "Ilce");

            migrationBuilder.DropTable(
                name: "Sehir");
        }
    }
}
