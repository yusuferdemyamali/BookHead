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
            migrationBuilder.AddColumn<int>(
                name: "KategoriId",
                table: "Kitaplar",
                type: "real",
                nullable: false,
                defaultValue: 0f);
            
        }



    }
}
