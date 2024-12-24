using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookHead.Migrations
{
    /// <inheritdoc />
    public partial class m : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Fiyat",
                table: "Kitaplar",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Satici",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Ayarlar",
                columns: table => new
                {
                    AyarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoResim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnaSayfaResim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkindaResim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GirisSayfaResim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkindaH2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HakkindaP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayarlar", x => x.AyarID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayarlar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "Kitaplar");

            migrationBuilder.DropColumn(
                name: "Satici",
                table: "Kitaplar");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Kitaplar");
        }
    }
}
