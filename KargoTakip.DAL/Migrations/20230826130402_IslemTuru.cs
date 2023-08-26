using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KargoTakip.DAL.Migrations
{
    public partial class IslemTuru : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KargoDetay_IslemTuru_IslemTuruId",
                table: "KargoDetay");

            migrationBuilder.RenameColumn(
                name: "IslemTuruId",
                table: "KargoDetay",
                newName: "IslemTuruID");

            migrationBuilder.RenameIndex(
                name: "IX_KargoDetay_IslemTuruId",
                table: "KargoDetay",
                newName: "IX_KargoDetay_IslemTuruID");

            migrationBuilder.AlterColumn<string>(
                name: "Pozisyon",
                table: "Personel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "KimlikNo",
                table: "Personel",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Cinsiyet",
                table: "Personel",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "IslemTuruID",
                table: "KargoDetay",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IslemTuru",
                table: "KargoDetay",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeslimEdenPersonelId",
                table: "Kargo",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_KargoDetay_IslemTuru_IslemTuruID",
                table: "KargoDetay",
                column: "IslemTuruID",
                principalTable: "IslemTuru",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KargoDetay_IslemTuru_IslemTuruID",
                table: "KargoDetay");

            migrationBuilder.DropColumn(
                name: "IslemTuru",
                table: "KargoDetay");

            migrationBuilder.RenameColumn(
                name: "IslemTuruID",
                table: "KargoDetay",
                newName: "IslemTuruId");

            migrationBuilder.RenameIndex(
                name: "IX_KargoDetay_IslemTuruID",
                table: "KargoDetay",
                newName: "IX_KargoDetay_IslemTuruId");

            migrationBuilder.AlterColumn<string>(
                name: "Pozisyon",
                table: "Personel",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KimlikNo",
                table: "Personel",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cinsiyet",
                table: "Personel",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IslemTuruId",
                table: "KargoDetay",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeslimEdenPersonelId",
                table: "Kargo",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KargoDetay_IslemTuru_IslemTuruId",
                table: "KargoDetay",
                column: "IslemTuruId",
                principalTable: "IslemTuru",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
