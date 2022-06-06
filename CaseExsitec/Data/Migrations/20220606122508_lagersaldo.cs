using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseExsitec.Data.Migrations
{
    public partial class lagersaldo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LagersaldoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produkt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Varelager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lagersaldo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LagersaldoModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LagersaldoModel");
        }
    }
}
