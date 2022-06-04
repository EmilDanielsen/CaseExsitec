using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseExsitec.Data.Migrations
{
    public partial class produkteradded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produkter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produktnr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pris = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkter", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkter");
        }
    }
}
