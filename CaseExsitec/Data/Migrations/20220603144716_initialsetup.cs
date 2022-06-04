using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseExsitec.Data.Migrations
{
    public partial class initialsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InnOgUtleveranse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Produkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TilFra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antall = table.Column<int>(type: "int", nullable: false),
                    InngåendeLagersaldo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnOgUtleveranse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InnOgUtleveranse");
        }
    }
}
